using eCodes.Services;
using eCodes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCodes.Models.SearchObjects;
using eCodes.Models.Requests;

namespace eCodes.Controllers
{
    public class OrdersController : BaseCRUDController<Models.Orders, OrderSearchObject, OrdersInsertRequest, OrdersUpdateRequest>
    {
        public OrdersController(IOrdersService orderService) : base(orderService)
        {
        }
    }
}
