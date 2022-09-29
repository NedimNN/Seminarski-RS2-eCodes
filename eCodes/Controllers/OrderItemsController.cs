using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    public class OrderItemsController : BaseCRUDController<Models.OrderItems, OrderItemsSearchObject, OrderItemsInsertRequest, OrderItemsUpdateRequest>
    {
        public OrderItemsController(IOrderItemsService orderItemsService) : base(orderItemsService)
        {
        }
    }
}
