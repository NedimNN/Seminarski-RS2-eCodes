using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCodes.Controllers
{
    public class ProductTypesController : BaseCRUDController<Models.ProductTypes, ProductTypeSearchObject, ProductTypesUpsertRequest, ProductTypesUpsertRequest>
    {
        public ProductTypesController(IProductTypesService service) 
            : base(service)
        {
        }

        [AllowAnonymous]
        public override IEnumerable<ProductTypes> Get([FromQuery] ProductTypeSearchObject search = null)
        {
            return base.Get(search);
        }

        [AllowAnonymous]
        public override ProductTypes GetbyId(int id)
        {
            return base.GetbyId(id);
        }
    }
}
