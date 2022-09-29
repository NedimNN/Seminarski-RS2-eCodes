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
    public class CountriesService : BaseCRUDService<Models.Countries, Database.Country, CountrySearchObject, CountryUpsertRequest, CountryUpsertRequest>, ICountriesService
    {
        public CountriesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Country> AddFilter(IQueryable<Country> query, CountrySearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(w => w.Name.Contains(search.Name));
            }

            return filter;
        }

    }
}
