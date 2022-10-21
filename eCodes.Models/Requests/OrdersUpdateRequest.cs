using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrdersUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public bool Status { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool? Canceled { get; set; }
        public virtual List<OrderItemsUpdateRequest> Items { get; set; }
    }
}
