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
    public class ProductTypesService : BaseCRUDService<Models.ProductTypes, Database.ProductType, ProductTypeSearchObject, ProductTypesUpsertRequest, ProductTypesUpsertRequest> , IProductTypesService
    {
        public ProductTypesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<ProductType> AddFilter(IQueryable<ProductType> query, ProductTypeSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if(!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(w=> w.Name.Contains(search.Name));
            }
            if (!string.IsNullOrWhiteSpace(search?.Region))
            {
                filter = filter.Where(w => w.Region.Contains(search.Region));
            }

            return filter;
        }

    }
}
