using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Ratings
    {
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Mark { get; set; }
        public virtual Buyers Buyer { get; set; }
    }
}
