using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;
using Microsoft.AspNetCore.Authorization;

namespace eCodes.Controllers
{

    public class ProductsController : BaseCRUDController<Models.Products, ProductSearchObjects, ProductsInsertRequest, ProductsUpdateRequest>
    {
        public IProductsService _productsService { get; set; }
        public ProductsController(IProductsService productsService)
            :base(productsService)
        {
            _productsService = productsService;
        }

        [HttpPut("{id}/Activate")]
        public Models.Products Activate(int id)
        {
            var result = _productsService.Activate(id);

            return result;
        }

        [HttpPut("{id}/Hide")]
        public Models.Products Hide(int id)
        {
            var result = _productsService.Hide(id);

            return result;
        }

        [HttpPut("{id}/AllowedActions")]
        public List<string> AllowedActions(int id)
        {
            var result = _productsService.AllowedActions(id);

            return result;
        }

        [HttpGet("{id}/Recommend")]
        [AllowAnonymous]
        public List<Products> Recommend(int id)
        {
            var result = _productsService.Recommend(id);

            return result;
        }

    }
}
