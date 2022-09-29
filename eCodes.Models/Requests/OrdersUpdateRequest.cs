using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrdersUpdateRequest
    {
        
        public bool Status { get; set; }
        public bool? Canceled { get; set; }
        public virtual List<OrderItemsUpdateRequest> Items { get; set; }
    }
}
