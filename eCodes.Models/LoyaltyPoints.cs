using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class LoyaltyPoints
    {
        public int LoyaltyPointsId { get; set; }
        public decimal Balance { get; set; }
        public int BuyerId { get; set; }
    }
}
