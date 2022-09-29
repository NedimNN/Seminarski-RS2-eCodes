using AutoMapper;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class CitiesService : BaseCRUDService<Models.Cities, Database.City, CitySearchObject, CityUpsertRequest, CityUpsertRequest>, ICitiesService
    {
        public CitiesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<City> AddFilter(IQueryable<City> query, CitySearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(w=> w.Name.Contains(search.Name));
            }
            if (!string.IsNullOrWhiteSpace(search?.CountryName))
            {
                filter = filter.Where(w => w.Country.Name.Contains(search.CountryName));
            }

            return filter;
        }
        public override void BeforeInsert(CityUpsertRequest insert, City dbentity)
        {
            //Insert the country before inserting city
            base.BeforeInsert(insert, dbentity);
        }

    }
}
