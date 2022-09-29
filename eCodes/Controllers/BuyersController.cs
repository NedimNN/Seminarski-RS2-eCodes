using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;


namespace eCodes.Controllers
{
    public class BuyersController : BaseCRUDController<Models.Buyers, BuyersSearchObject, BuyerInsertRequest, BuyerUpdateRequest>
    {
        public BuyersController(IBuyersService buyersService)
            : base(buyersService)
        {

        }

    }
}
