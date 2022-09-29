using AutoMapper;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class PersonsService : BaseCRUDService<Models.Persons, Database.Person, PersonSearchObject, PersonInsertRequest, PersonUpdateRequest>, IPersonsService
    {
        public PersonsService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Person> AddInclude(IQueryable<Person> query, PersonSearchObject search = null)
        {
            query = query.Include(i=> i.City);
            return query;
        }
        public override Person AddIncludeforGetById(Person query)
        {
            query.City = _context.Cities.Where(w => w.CityId == query.CityId).FirstOrDefault();
            return query;
        }

        public override IQueryable<Person> AddFilter(IQueryable<Person> query, PersonSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.NameFTS))
            {
                filter = filter.Where(w=> w.FirstName.Contains(search.NameFTS) || w.LastName.Contains(search.NameFTS));
            }

            if (!string.IsNullOrWhiteSpace(search?.Jmbg))
            {
                filter = filter.Where(w => w.Jmbg == search.Jmbg);
            }

            if (!string.IsNullOrWhiteSpace(search?.Gender))
            {
                filter = filter.Where(w=> w.Gender.Contains(search.Gender));
            }

            return filter;
        }
        public override void BeforeInsert(PersonInsertRequest insert, Person dbentity)
        {
            //Should implement the edge cases for users sending empty string or entering a city that is not in database

            var cityserivce = new CitiesService(_context, _mapper);
            CitySearchObject citysearch = new CitySearchObject();

            citysearch.Name = insert.CityName;
            var city = cityserivce.Get(citysearch);

            if(!string.IsNullOrWhiteSpace(citysearch.Name)) 
            {
                if (city.FirstOrDefault() != null)
                {
                    dbentity.City = _mapper.Map<City>(city.FirstOrDefault());
                    dbentity.CityId = city.FirstOrDefault().CityId;
                }
                else
                {
                    dbentity.City = null;
                    dbentity.CityId = 1;
                }
            }
            else
            {
                dbentity.City = null;
                dbentity.CityId = 1;
            }
           

           base.BeforeInsert(insert, dbentity);
        }

    }
}
