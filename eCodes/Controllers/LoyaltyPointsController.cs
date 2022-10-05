using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{

    public class LoyaltyPointsController : BaseCRUDController<Models.LoyaltyPoints, LoyaltyPointsSearchObject, LoyaltyPointsUpsertRequest, LoyaltyPointsUpsertRequest>
    {

        public LoyaltyPointsController(ILoyaltyPointService loyaltyPointsService)
            : base(loyaltyPointsService)
        {

        }

    }
}