using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrderItemsInsertRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
