using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;
using Microsoft.AspNetCore.Authorization;

namespace eCodes.Controllers
{
    public class SellersController : BaseCRUDController<Models.Sellers, SellerSearchObject, SellerInsertRequest, SellerUpdateRequest>
    {
        public SellersController(ISellersService sellerService) : base(sellerService)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public override Sellers Insert([FromBody] SellerInsertRequest insert)
        {
            return base.Insert(insert);
        }

    }
}
