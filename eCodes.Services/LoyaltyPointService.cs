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
    public class LoyaltyPointService : BaseCRUDService<Models.LoyaltyPoints, Database.LoyaltyPoint, LoyaltyPointsSearchObject, LoyaltyPointsUpsertRequest, LoyaltyPointsUpsertRequest>, ILoyaltyPointService
    {
        public LoyaltyPointService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<LoyaltyPoint> AddFilter(IQueryable<LoyaltyPoint> query, LoyaltyPointsSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search?.BuyerId > 0)
            {
                filter = filter.Where(w => w.BuyerId == search.BuyerId);
            }

            return filter;
        }
    }
}
