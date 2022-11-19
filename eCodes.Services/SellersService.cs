using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCodes.Services.HelperMethods;
using eCodes.Services.ProductStateMachine;
using eCodes.Models.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCodes.Services
{
    public class SellersService : BaseCRUDService<Models.Sellers, Database.Seller, SellerSearchObject, SellerInsertRequest, SellerUpdateRequest>, ISellersService
    {
        public ProductBaseState BaseState { get; set; }

        public SellersService(_210331Context context, IMapper mapper, ProductBaseState baseState) : base(context, mapper)
        {
            BaseState = baseState;
        }
        public override IQueryable<Seller> AddInclude(IQueryable<Seller> query, SellerSearchObject search = null)
        {
            if (search?.IncludePerson == true)
            {
                query = query.Include("Person");
            }

            return query;
        }
        public override Seller AddIncludeforGetById(Seller query)
        {
            query.Person = _context.Persons.Where(w => w.PersonId == query.PersonId).FirstOrDefault();
            return query;
        }

        public override void BeforeDelete(Seller dbentity)
        {
            var productsService = new ProductsService(_context, _mapper, BaseState);
            List<Product> productsToDel = new List<Product>();
            var products = _context.Products.Where(w => w.SellerId == dbentity.SellerId).ToList();
            productsToDel = products;
            foreach(var product in productsToDel)
            {
                product.StateMachine = "hidden";
                productsService.Delete(product.ProductId);
            }

            var ratingService = new RatingService(_context, _mapper);
            RatingSearchObject searchRating = new RatingSearchObject() { SellerId = dbentity.SellerId };
            var ratings = ratingService.Get(searchRating);

            foreach (var item in ratings)
            {
                ratingService.Delete(item.RatingId);
            }

            base.BeforeDelete(dbentity);
        }
        public override void AfterDelete(Seller dbentity)
        {
            var personService = new PersonsService(_context, _mapper);
            personService.Delete(dbentity.PersonId);
            base.AfterDelete(dbentity);
        }
        public override void BeforeInsert(SellerInsertRequest insert, Seller dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, insert.Password);

            base.BeforeInsert(insert, dbentity);
        }
        public override void BeforeUpdate(SellerUpdateRequest update, Seller dbentity)
        {
            var salt = HashingAndSaltingMethod.GenerateSalt();
            dbentity.PasswordSalt = salt;
            dbentity.PasswordHash = HashingAndSaltingMethod.GenerateHash(salt, update.Password);

            base.BeforeUpdate(update, dbentity);
        }
        public override Sellers Insert(SellerInsertRequest insert)
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


            //First insert person then the seller
            var personService = new PersonsService(_context, _mapper);
            var person = _mapper.Map<PersonInsertRequest>(insert);

            var tempperson = personService.Insert(person);
            insert.PersonId = tempperson.PersonId;
            var dbentity = base.Insert(insert);

            _context.SaveChanges();
            return dbentity;
        }

        public override Sellers Update(int id, SellerUpdateRequest update)
        {
            var seller = _context.Sellers.FirstOrDefault(x => x.SellerId == id);

            //First update the person properties
            var personService = new PersonsService(_context, _mapper);
            var updatedPerson = _mapper.Map<PersonUpdateRequest>(update);
            personService.Update(seller.PersonId, updatedPerson);
            //----------------------------------

            return base.Update(seller.SellerId, update);
        }
        
        public override IQueryable<Seller> AddFilter(IQueryable<Seller> query, SellerSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(w => w.Name.Contains(search.Name));
            }
            if (!string.IsNullOrWhiteSpace(search?.Email))
            {
                filter = filter.Where(w => w.Email.Contains(search.Email));
            }
            if (!string.IsNullOrWhiteSpace(search?.Address))
            {
                filter = filter.Where(w => w.Address.Contains(search.Address));
            }
            if (!string.IsNullOrWhiteSpace(search?.PhoneNumber))
            {
                filter = filter.Where(w => w.PhoneNumber.Contains(search.PhoneNumber));
            }
            if(search?.Status == false)
            {
                filter = filter.Where(w => w.Status == false);
            }
            else
            {
                filter = filter.Where(w => w.Status == true);
            }
            return filter;
        }

        public Sellers Login(string username, string password)
        {
            var entity = _context.Sellers.Where(w=> w.Name == username).FirstOrDefault();


            if (entity == null || entity.Status == false) // entity.Status == false because if the seller requested deletion he should not be able to login
                return null;

            var hash = HashingAndSaltingMethod.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
                return null;

            return _mapper.Map<Models.Sellers>(entity);
        }
        public Sellers RequestDelete(int id)
        {
            var seller = _context.Sellers.Find(id);
            seller.Status = false;
            _context.SaveChanges();

            return _mapper.Map<Models.Sellers>(seller);
        }
    }
}
