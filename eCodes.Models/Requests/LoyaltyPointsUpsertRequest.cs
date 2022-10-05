using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class LoyaltyPointsUpsertRequest
    {
        public decimal Balance { get; set; }
        public int BuyerId { get; set; }
    }
}
