using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class OutputItems
    {
        public int OutputId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int SellerId { get; set; }


    }
}
