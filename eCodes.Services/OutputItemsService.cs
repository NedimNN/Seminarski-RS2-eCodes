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
    public class OutputItemsService : BaseCRUDService<Models.OutputItems, Database.OutputItem, BaseSearchObject, OutputItemUpsertRequest, OutputItemUpsertRequest>, IOutputItemsService
    {
        public OutputItemsService(_210331Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
