using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{

    public class OutputController : BaseCRUDController<Models.Outputs, OutputSearchObject, OutputUpsertRequest, OutputUpsertRequest>
    {

        public OutputController(IOutputService outputService)
            : base(outputService)
        {

        }

    }
}

