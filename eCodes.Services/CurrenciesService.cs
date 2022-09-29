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
    public class CurrenciesService : BaseCRUDService<Models.Currencies, Database.Currency, BaseSearchObject, CurrencyUpsertRequest, CurrencyUpsertRequest>, ICurrenciesService
    {
        public CurrenciesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
