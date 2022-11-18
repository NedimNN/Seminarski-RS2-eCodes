using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCodes.Services.HelperMethods;
using Microsoft.EntityFrameworkCore;
using eCodes.Models.Exceptions;

namespace eCodes.Services
{
    public class EmployeesService : BaseCRUDService<Models.Employees, Database.Employee, EmployeeSearchObject, EmployeeInsertRequest, EmployeeUpdateRequest>, IEmployeeService
    {
        public EmployeesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Employee> AddInclude(IQueryable<Employee> query, EmployeeSearchObject search = null)
        {

            if (search?.IncludePerson == true)
            {
                query = query.Include("Person.City");
            }

            return query;
        }
        public override IQueryable<Employee> AddFilter(IQueryable<Employee> query, EmployeeSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);
            var date = new DateTime();
            if(search?.EmployeeNumber != 0)
            {
                filter = filter.Where(w => w.EmployeeNumber == search.EmployeeNumber);
            }
            if (search?.DateOfEmployement != date.Date)
            {
                filter = filter.Where(w => w.DateOfEmployement.Date.Equals(search.DateOfEmployement.Date));
            }
            return filter;
        }
        public override void AfterDelete(Employee dbentity)
        {
            var personService = new PersonsService(_context, _mapper);
            personService.Delete(dbentity.PersonId);

            base.AfterDelete(dbentity);
        }
        public override void BeforeInsert(EmployeeInsertRequest insert, Employee dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, insert.Password);

            base.BeforeInsert(insert, dbentity);
        }


        public override Employees Insert(EmployeeInsertRequest insert)
        {
            if (insert.Password != insert.PasswordConfirmation)
            {
                throw new UserErrorException("Password and confirmation must be the same");
            }

            var cities = _context.Cities.Where(w => w.Name == insert.CityName);
            if (!cities.Any())
            {
                throw new UserErrorException("City name is not valid !");
            }


            //First insert person then the buyer
            var personService = new PersonsService(_context, _mapper);
            var person = _mapper.Map<PersonInsertRequest>(insert);

            var tempperson = personService.Insert(person);
            insert.PersonId = tempperson.PersonId;
            insert.DateOfEmployement = DateTime.Now;
            insert.EmployeeNumber = _context.Employees.Count() + 1;
            var dbentity = base.Insert(insert);

            _context.SaveChanges();
            return dbentity;
        }

        public Employees Login(string username, string password)
        {
            var entity = _context.Employees.Where(w => Convert.ToString(w.EmployeeNumber) == username).FirstOrDefault();


            if (entity == null)
                return null;

            var hash = HashingAndSaltingMethod.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
                return null;

            return _mapper.Map<Models.Employees>(entity);
        }
        public override void BeforeUpdate(EmployeeUpdateRequest update, Employee dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, update.Password);

            base.BeforeUpdate(update, dbentity);
        }
        public override Employees Update(int id, EmployeeUpdateRequest update)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);

            //First update the person properties
            var personService = new PersonsService(_context, _mapper);
            var updatedPerson = _mapper.Map<PersonUpdateRequest>(update);
            personService.Update(employee.PersonId, updatedPerson);
            //----------------------------------

            return base.Update(employee.EmployeeId, update);
        }


    }
}
