using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = null!;
        public decimal Mark { get; set; }
        public int ProductId { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Seller Seller { get; set; } = null!;
    }
}
