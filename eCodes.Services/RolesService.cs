using AutoMapper;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public class RolesService : BaseService<Models.Roles, Database.Role, RolesSearchObject>, IRolesService
    {
        public RolesService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Role> AddFilter(IQueryable<Role> query, RolesSearchObject search = null)
        {
            var filter =  base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(w => w.Name.Contains(search.Name));
            }

            return filter;
        }

    }
}
