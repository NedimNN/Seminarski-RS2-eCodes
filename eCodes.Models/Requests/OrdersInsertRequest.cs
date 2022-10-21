using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrdersInsertRequest
    {
        public List<OrderItemsInsertRequest> Items { get; set; } = new List<OrderItemsInsertRequest>();
        [Required(AllowEmptyStrings = false)]
        public bool Status { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool? Canceled { get; set; }

    }
}
