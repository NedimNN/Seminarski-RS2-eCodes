using AutoMapper;
using eCodes.Models.Exceptions;
using eCodes.Models.Requests;
using eCodes.Services.Database;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services.ProductStateMachine
{
    public class ProductBaseState
    {
        public IMapper _mapper { get; set; }
        public _210331Context _context { get; set; } = null;
        public IServiceProvider ServiceProvider { get; set; }
        public Database.Product CurrentEntity { get;set; }

        public ProductBaseState(IMapper mapper, IServiceProvider serviceProvider, _210331Context context)
        {
            _mapper = mapper;
            ServiceProvider = serviceProvider;
            _context = context;
        }

        public virtual Models.Products Insert(ProductsInsertRequest request)
        {
            throw new Exception("Not implemented!!!");
        }

        public virtual void Update(ProductsUpdateRequest request)
        {
            throw new Exception("Not implemented!!!");
        }

        public virtual void Activate()
        {
            throw new Exception("Not implemented!!!");
        }

        public virtual void Hide()
        {
            throw new Exception("Not implemented!!!");
        }

        public virtual bool Delete()
        {
            throw new ProductException("Can't delete this product beacuse the current state of this product is " + this.CurrentEntity.StateMachine + "!");
        }

        public ProductBaseState CreateState(string stateName)
        {
            switch (stateName)
            {
                case "initial":
                    return ServiceProvider.GetService<InitialProductState>();
                    break;
                case "draft":
                    return ServiceProvider.GetService<DraftProductState>();
                case "active":
                    return ServiceProvider.GetService<ActiveProductState>();
                case "hidden":
                    return ServiceProvider.GetService<HiddenProductState>();
                default:
                    throw new Exception("Not supported!");
            }
        }
        public virtual List<string> AllowedActions()
        {
            return new List<string>();
        }

    }
}
