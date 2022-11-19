using AutoMapper;
using eCodes.Models;
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
    public class OutputItemsService : BaseCRUDService<Models.OutputItems, Database.OutputItem, OutputItemsSearchObject, OutputItemUpsertRequest, OutputItemUpsertRequest>, IOutputItemsService
    {
        public OutputItemsService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
        public override IQueryable<OutputItem> AddFilter(IQueryable<OutputItem> query, OutputItemsSearchObject search = null)
        {
            var filter = base.AddFilter(query, search);

            if(search?.ProductId > 0)
            {
                filter = filter.Where(w=> w.ProductId == search.ProductId);
            }
            if (search?.OutputId > 0)
            {
                filter = filter.Where(w => w.OutputId == search.OutputId);
            }


            return filter;
        }

    }
}
