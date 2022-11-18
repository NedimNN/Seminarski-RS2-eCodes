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
    public class OutputService : BaseCRUDService<Models.Outputs, Database.Output, OutputSearchObject, OutputUpsertRequest, OutputUpsertRequest>, IOutputService
    {
        public OutputService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<Output> AddFilter(IQueryable<Output> query, OutputSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);
            if (!string.IsNullOrWhiteSpace(search?.BuyerName))
            {
                filter = filter.Include(i=> i.Buyer).Where(w => w.Buyer.Username == search.BuyerName );
            }

            return filter;
        }
        public override IQueryable<Output> AddInclude(IQueryable<Output> query, OutputSearchObject search = null)
        {
            if (search?.Include == true)
            {
                query = query.Include(i => i.Buyer.Person);
                query = query.Include(i => i.OutputItems);
            }

            return query;
        }
    }
}
