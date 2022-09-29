using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCodes.Controllers
{
    public class RolesController : BaseController<Models.Roles, RolesSearchObject>
    {
        public RolesController(IRolesService service) 
            : base(service)
        {
        }

    }
}
