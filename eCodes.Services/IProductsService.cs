using eCodes.Models;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public interface IProductsService: ICRUDService<Products, ProductSearchObjects, ProductsInsertRequest, ProductsUpdateRequest>
    {
       Models.Products Activate(int id);
       Models.Products Hide(int id);
       List<string> AllowedActions(int id);
        List<Models.Products> Recommend(int id);
        ITransformer ModelTrainer ();

    }
}
