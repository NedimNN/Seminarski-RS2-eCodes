using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrdersInsertRequest
    {
        public List<OrderItemsInsertRequest> Items { get; set; } = new List<OrderItemsInsertRequest>();

    }
}
