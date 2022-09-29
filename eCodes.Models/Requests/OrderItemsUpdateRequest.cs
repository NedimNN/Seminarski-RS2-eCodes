using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrderItemsUpdateRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
