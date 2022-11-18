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
    public class OrderItemsService : BaseCRUDService<Models.OrderItems, Database.OrderItem, OrderItemsSearchObject, OrderItemsInsertRequest, OrderItemsUpdateRequest>, IOrderItemsService
    {
        public OrderItemsService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<OrderItem> AddFilter(IQueryable<OrderItem> query, OrderItemsSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if(search.OrderId > 0)
            {
                filter = filter.Where(w => w.OrderId == search.OrderId);
            }
            if(search.ProductId > 0)
            {
                filter = filter.Where(w=> w.ProductId== search.ProductId);
            }

            return filter;
        }
        public override IQueryable<OrderItem> AddInclude(IQueryable<OrderItem> query, OrderItemsSearchObject search = null)
        {
            query = query.Include("Product.ProductType");
            query = query.Include("Product.Seller");
            return query;
        }

    }
}
