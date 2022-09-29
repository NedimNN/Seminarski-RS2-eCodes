using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    public class RatingController : BaseCRUDController<Models.Ratings, RatingSearchObject, RatingUpsertRequest, RatingUpsertRequest>
    {
        public RatingController(IRatingsService ratingService) : base(ratingService)
        {
        }
    }
}
