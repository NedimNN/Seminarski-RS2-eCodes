using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Ratings
    {
        public int RatingId { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Mark { get; set; }
        public int ProductId { get; set; }

        public virtual Buyers Buyer { get; set; } 
        public virtual Products Product { get; set; } 
        public virtual Sellers Seller { get; set; } 

    }
}
