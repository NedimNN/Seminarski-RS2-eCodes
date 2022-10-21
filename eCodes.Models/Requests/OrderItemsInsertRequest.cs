using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrderItemsInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public int OrderId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int ProductId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int Quantity { get; set; }
    }
}
