using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eCodes.Services.HelperMethods;
using Microsoft.EntityFrameworkCore;
using eCodes.Models.Exceptions;

namespace eCodes.Services
{
    public class BuyersService : BaseCRUDService<Models.Buyers, Database.Buyer, BuyersSearchObject, BuyerInsertRequest, BuyerUpdateRequest>, IBuyersService
    {
        public BuyersService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Buyer> AddInclude(IQueryable<Buyer> query, BuyersSearchObject search = null)
        {
            if (search?.IncludePerson == true)
            {
                query = query.Include(i => i.Person);

            }

            return query;
        }
        public override void BeforeDelete(Buyer dbentity)
        {
            var personService = new PersonsService(_context, _mapper);
            personService.Delete(dbentity.PersonId);

            base.BeforeDelete(dbentity);
        }
        public override Buyer AddIncludeforGetById(Buyer query)
        {
            query.Person = _context.Persons.Where(w => w.PersonId == query.PersonId).FirstOrDefault();
            if (query.Person != null)
                query.Person.City = _context.Cities.Where(w => w.CityId == query.Person.CityId).FirstOrDefault();
            return query;
        }

        public override IQueryable<Buyer> AddFilter(IQueryable<Buyer> query, BuyersSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                filter = filter.Where(w => w.Email.Contains(search.Email));
            }

            if (!string.IsNullOrWhiteSpace(search?.Username))
            {
                filter = filter.Where(w=> w.Username == search.Username);
            }

            return filter;
        }
        public override Buyers Insert(BuyerInsertRequest insert)
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
            insert.RegistrationDate = DateTime.Now;
            insert.Status = true;
            var dbentity = base.Insert(insert);
            var walletService = new WalletsService(_context, _mapper);
            WalletUpsertRequest insertWallet = new WalletUpsertRequest();
            insertWallet.CurrencyId = 1;
            insertWallet.BuyerId = dbentity.BuyerId;
            insertWallet.Balance = 0;
            var wallet = walletService.Insert(insertWallet);

            _context.SaveChanges();
            return dbentity;
        }

        public override Buyers Update(int id, BuyerUpdateRequest update)
        {
            if (update.Password != update.PasswordConfirmation)
            {
                throw new UserErrorException("Password and confirmation must be the same");
            }

            var buyer = _context.Buyers.FirstOrDefault(x => x.BuyerId == id);

            //First update the person properties
            var personService = new PersonsService(_context, _mapper);
            var updatedPerson = _mapper.Map<PersonUpdateRequest>(update);
            personService.Update(buyer.PersonId, updatedPerson);
            //----------------------------------

            return base.Update(buyer.BuyerId, update);
        }

        public override void BeforeInsert(BuyerInsertRequest insert, Buyer dbentity)
        {
            
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, insert.Password);

            base.BeforeInsert(insert, dbentity);
        }
        public override void BeforeUpdate(BuyerUpdateRequest update, Buyer dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, update.Password);

            base.BeforeUpdate(update, dbentity);
        }
        public Buyers Login(string username, string password)
        {
            var entity = _context.Buyers.Where(w => w.Username == username).FirstOrDefault();


            if (entity == null)
                return null;

            var hash = HashingAndSaltingMethod.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
                return null;

            return _mapper.Map<Models.Buyers>(entity);
        }

    }
}
