using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OrderItemsUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public int ProductId { get; set; }

    }
}
