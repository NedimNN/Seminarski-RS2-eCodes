using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    public class CurrencyController : BaseCRUDController<Models.Currencies, BaseSearchObject, CurrencyUpsertRequest, CurrencyUpsertRequest>
    {
        public CurrencyController(ICurrenciesService currencyService)
            : base(currencyService)
        {
        }
    }

}
