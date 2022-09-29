using AutoMapper;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services.ProductStateMachine
{
    public class ActiveProductState : ProductBaseState
    {
        public ActiveProductState(IMapper mapper, IServiceProvider serviceProvider, _210331Context context) : base(mapper, serviceProvider, context)
        {
        }

        public override void Hide()
        {
            CurrentEntity.StateMachine = "hidden";
            _context.SaveChanges();
        }

        public override List<string> AllowedActions()
        {
            var list = base.AllowedActions();

            list.Add("hide");

            return list;
        }

    }
}
