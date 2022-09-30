using AutoMapper;
using eCodes.Models;
using eCodes.Models.Exceptions;
using eCodes.Models.Requests;
using eCodes.Models.SearchObjects;
using eCodes.Services.Database;
using eCodes.Services.ProductStateMachine;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace eCodes.Services
{
    public class ProductsService : BaseCRUDService<Models.Products,Database.Product,ProductSearchObjects,ProductsInsertRequest, ProductsUpdateRequest>, IProductsService
    {
        public ProductBaseState BaseState { get; set; }
        public ProductsService(_210331Context context, IMapper mapper, ProductBaseState baseState) : base(context, mapper)
        {
            BaseState = baseState;
        }
        public override Products Insert(ProductsInsertRequest insert)
        {
            var state = BaseState.CreateState("initial");
            
            return state.Insert(insert);
        }
        public override Products Delete(int id)
        {
            var product = _context.Products.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state._context = _context;

            state.CurrentEntity = product;

            if(state.Delete())
                return base.Delete(id);
            else
                throw new ProductException("Can't delete this product beacuse the current state of this product is " + state.CurrentEntity.StateMachine + "!");
        }
        public override Products Update(int id, ProductsUpdateRequest update)
        {
            var product = _context.Products.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state._context = _context;

            state.CurrentEntity = product;
            
            state.Update(update);

            return GetbyId(id);
        }
        public Models.Products Activate (int id)
        {
            var product = _context.Products.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Activate();

            return GetbyId(id);
        }

        public Products Hide(int id)
        {
            var product = _context.Products.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            state.CurrentEntity = product;

            state.Hide();

            return GetbyId(id);
        }

        public List<string> AllowedActions(int id)
        {
            var product = _context.Products.Find(id);

            var state = BaseState.CreateState(product.StateMachine);

            return state.AllowedActions();
        }


        public override IQueryable<Product> AddFilter(IQueryable<Product> query, ProductSearchObjects search = null)
        {
            var filter = base.AddFilter(query, search);

            if (!string.IsNullOrWhiteSpace(search?.SellerName) && !string.IsNullOrWhiteSpace(search?.StateMachine) && search.StateMachine == "all")
            {
                filter = filter.Where(w => w.Seller.Name.Equals(search.SellerName));
                return filter;
            }
            else if(!string.IsNullOrWhiteSpace(search?.SellerName))
            {
                filter = filter.Where(w => w.Seller.Name.Equals(search.SellerName));
            }
            if (!string.IsNullOrWhiteSpace(search?.Code))
            {
                filter = filter.Where(x => x.Code.Equals(search.Code));
            }

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                filter = filter.Where(x => x.Name.Contains(search.Name));
            }

            if (search?.Price != null)
            {
                filter = filter.Where(x => x.Price >= search.Price);
            }

            if(!string.IsNullOrWhiteSpace(search?.Duration))
            {
                filter = filter.Where(w=> w.Duration.Contains(search.Duration));
            }

            if (!string.IsNullOrWhiteSpace(search?.Version))
            {
                filter = filter.Where(w => w.Version.Contains(search.Version));
            }
            if (!string.IsNullOrWhiteSpace(search?.Platform))
            {
                filter = filter.Where(w => w.Platform == search.Platform);
            }
            if (!string.IsNullOrWhiteSpace(search?.StateMachine))
            {
                filter = filter.Where(w => w.StateMachine.Equals(search.StateMachine));
            }
           

            return filter;
        }
        public override IQueryable<Product> AddInclude(IQueryable<Product> query, ProductSearchObjects search = null)
        {
            if (search?.IncludeType == true)
            {
                query = query.Include(i=> i.ProductType);
                query = query.Include(i => i.Seller);
            }

            return query;
        }
        public override Product AddIncludeforGetById(Product query)
        {
            query.ProductType = _context.ProductTypes.Where(w => w.ProductTypeId == query.ProductTypeId).FirstOrDefault();
            query.Seller = _context.Sellers.Where(w => w.SellerId == query.SellerId).FirstOrDefault();

            return query;
        }

        static MLContext mlContext = null;
        static ITransformer model = null;

        public List<Products> Recommend(int id)
        {
            //Implement either cache or database to store the trained model and the prediction so it does not train or predict everytime someone calls it
            var allItems = _context.Products.Where(w => w.ProductId != id);
            var trainedModel = ModelTrainer();

            var predictionResult = new List<Tuple<Database.Product, float>>();
            foreach (var item in allItems)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductEntry,Copurchase_prediction>(trainedModel);

                var prediction = predictionEngine.Predict(new ProductEntry()
                {
                    ProductID = (uint)id,
                    CoPurchaseProductID = (uint)item.ProductId
                });

                predictionResult.Add(new Tuple<Database.Product, float>(item, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(o => o.Item2).Select(s => s.Item1).Take(3).ToList();

            return _mapper.Map<List<Models.Products>>(finalResult);
        }

        public ITransformer ModelTrainer()
        {
            if(mlContext == null) { 
                 mlContext = new MLContext();

                 var tmp = _context.Orders.Include(i => i.OrderItems).ToList();
                 var data = new List<ProductEntry>();

                 foreach (var item in tmp)
                 {
                     if (item.OrderItems.Count > 1)
                     {
                         var distinctItemId = item.OrderItems.Select(s => s.ProductId).ToList();

                         distinctItemId.ForEach(x =>
                         {
                             var relatedItems = item.OrderItems.Where(w => w.ProductId != x);

                             foreach (var y in relatedItems)
                             {
                                 data.Add(new ProductEntry()
                                 {
                                     ProductID = (uint)x,
                                     CoPurchaseProductID = (uint)y.ProductId,

                                 });
                             }

                         });
                     }
                 }

                 var trainData = mlContext.Data.LoadFromEnumerable(data);

                 MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options();
                 options.MatrixColumnIndexColumnName = nameof(ProductEntry.ProductID);
                 options.MatrixRowIndexColumnName = nameof(ProductEntry.CoPurchaseProductID);
                 options.LabelColumnName = "Label";
                 options.LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass;
                 options.Alpha = 0.01;
                 options.Lambda = 0.025;
                 // For better results use the following parameters
                 options.NumberOfIterations = 100;
                 options.C = 0.00001;

                 var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                 model = est.Fit(trainData);
            }

            return model;
        }
    }
    public class Copurchase_prediction
    {
        public float Score { get; set; }
    }

    public class ProductEntry
    {
        [KeyType(count: 10)]
        public uint ProductID { get; set; }
        [KeyType(count: 10)]
        public uint CoPurchaseProductID { get; set; }
        public float Label { get; set; }
    }
}