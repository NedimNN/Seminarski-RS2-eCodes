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
    public class RatingService : BaseCRUDService<Models.Ratings, Database.Rating, RatingSearchObject, RatingUpsertRequest, RatingUpsertRequest>, IRatingsService
    {
        public RatingService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Rating> AddFilter(IQueryable<Rating> query, RatingSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search?.SellerId > 0)
            {
                filter = filter.Where(w => w.SellerId.Equals(search.SellerId));
            }
            if (search?.ProductId > 0)
            {
                filter = filter.Where(w => w.ProductId.Equals(search.ProductId));
            }

            return filter;
        }
        public override IQueryable<Rating> AddInclude(IQueryable<Rating> query, RatingSearchObject search = null)
        {
            query = query.Include(i => i.Buyer);
            query = query.Include(i => i.Product.ProductType.Currency);

            return base.AddInclude(query, search);
        }
        public override void BeforeInsert(RatingUpsertRequest insert, Rating dbentity)
        {
            dbentity.Date = DateTime.Now;

            base.BeforeInsert(insert, dbentity);
        }

    }
}
