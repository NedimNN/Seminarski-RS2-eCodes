using AutoMapper;
using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services.ProductStateMachine
{
    public class InitialProductState : ProductBaseState
    {
        public InitialProductState(IMapper mapper, IServiceProvider serviceProvider, _210331Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override Products Insert(ProductsInsertRequest request)
        {
            var set = _context.Set<Database.Product>();

            Database.Product entity = _mapper.Map<Database.Product>(request);
            CurrentEntity = entity;
            CurrentEntity.StateMachine = "draft";

            set.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Products>(entity);
        }

    }
}
