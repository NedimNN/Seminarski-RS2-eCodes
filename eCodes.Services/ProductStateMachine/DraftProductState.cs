using AutoMapper;
using eCodes.Models.Requests;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace eCodes.Services.ProductStateMachine
{
    public class DraftProductState : ProductBaseState
    {
        public DraftProductState(IMapper mapper, IServiceProvider serviceProvider, _210331Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override void Update(ProductsUpdateRequest request)
        {
            var set = _context.Set<Database.Product>();
            var entity = set.Find(CurrentEntity.ProductId);

            if (entity != null)
            {
                _mapper.Map(request, entity);
            }
            else
                return;

            CurrentEntity.StateMachine = request.StateMachine;
            _context.SaveChanges();
        }

        public override void Activate()
        {
            CurrentEntity.StateMachine = "active";
            _context.SaveChanges();
        }
        public override bool Delete()
        {
            return true;
        }

        public override List<string> AllowedActions()
        {
            var list =  base.AllowedActions();

            list.Add("update");
            list.Add("activate");
            list.Add("hide");


            return list;
        }

    }
}
