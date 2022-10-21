using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class OutputItem
    {
        public int OutputItemsId { get; set; }
        public int OutputId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int SellerId { get; set; }

        public virtual Output Output { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
    }
}
