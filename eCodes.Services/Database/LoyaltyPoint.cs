using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class LoyaltyPoint
    {
        public int LoyaltyPointsId { get; set; }
        public decimal Balance { get; set; }
        public int BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
    }
}
