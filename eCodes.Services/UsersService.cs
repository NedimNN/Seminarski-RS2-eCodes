using AutoMapper;
using eCodes.Models;
using eCodes.Services.HelperMethods;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCodes.Models.Exceptions;

namespace eCodes.Services
{
    public class UsersService : BaseCRUDService<Models.Users, Database.User, UserSearchObject, UserInsertRequest,UserUpdateRequest>, IUsersService
    {
        public UsersService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<User> AddInclude(IQueryable<User> query, UserSearchObject search = null)
        {

            if(search?.IncludeRoles == true)
            {
                query = query.Include("UserRoles.Role");
                query = query.Include("Person");
            }

            return query;
        }
        public override IQueryable<Database.User> AddFilter(IQueryable<Database.User> query, UserSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                filter = filter.Where(x => x.Username.Contains(search.Username));
            }
            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                filter = filter.Where(w=> w.Email.Contains(search.Email));
            }
            if (!string.IsNullOrWhiteSpace(search?.PhoneNumber))
            {
                filter = filter.Where(w => w.PhoneNumber.Contains(search.PhoneNumber));
            }

            
            return filter;
        }

        public override Users Insert(UserInsertRequest insert)
        {
            if(insert.Password != insert.PasswordConfirmation)
            {
                throw new UserErrorException("Password and confirmation must be the same");
            }
            var cities = _context.Cities.Where(w => w.Name == insert.CityName);
            if (!cities.Any())
            {
                throw new UserErrorException("City name is not valid !");
            }


            //First insert the person and then the user

            var personService = new PersonsService(_context,_mapper);
            var person = _mapper.Map<PersonInsertRequest>(insert);
            
            var tempperson = personService.Insert(person);
            insert.PersonId = tempperson.PersonId;
            var dbentity = base.Insert(insert);
            
            //Validation for user roles
            var existingroles = _context.Roles.ToList();
            List<int> existingRolesForUser = new List<int>();

            foreach (var roleId in insert.UserRolesIdList)
            {
                if (roleId - 1 >= 0 && roleId - 1 <= existingroles.Count - 1)
                {
                    if (existingroles[roleId - 1].RoleId == roleId && existingRolesForUser.Contains(roleId) == false)
                    {
                        Database.UserRole userRole = new UserRole();
                        userRole.RoleId = roleId;
                        userRole.UserId = dbentity.UserId;
                        userRole.Date = DateTime.Now;

                        _context.UserRoles.Add(userRole);
                        existingRolesForUser.Add(roleId);
                    }
                }
            }
            _context.SaveChanges();
            return dbentity;
        }
        public override void BeforeUpdate(UserUpdateRequest update, User dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, update.Password);

            base.BeforeUpdate(update, dbentity);
        }
        public override Users Update(int id, UserUpdateRequest update)
        {
            if(update.Password != update.PasswordConfirmation)
            {
                throw new UserErrorException("Password and confirmation must be the same");
            }

            var user = _context.Users.FirstOrDefault(x => x.UserId == id);

            //First update the person properties
            var personService = new PersonsService(_context, _mapper);
            //var person = _context.Persons.FirstOrDefault(x => x.PersonId == user.PersonId);
            var updatedPerson = _mapper.Map<PersonUpdateRequest>(update);
            personService.Update(user.PersonId, updatedPerson);
            //----------------------------------

            return base.Update(user.UserId, update); 
        }

        public override void BeforeInsert(UserInsertRequest insert, User dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, insert.Password);
            
            base.BeforeInsert(insert, dbentity);
        }
        public override void BeforeDelete(User dbentity)
        {
            var personService = new PersonsService(_context, _mapper);
            personService.Delete(dbentity.PersonId);

            base.BeforeDelete(dbentity);
        }

        public Models.Users Login(string username, string password)
        {
            var entity = _context.Users.Include("UserRoles.Role").FirstOrDefault(x => x.Username == username);

            if (entity == null)
                return null;

            var hash = HashingAndSaltingMethod.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
                return null;

            return _mapper.Map<Models.Users>(entity);
        }

    }
}
