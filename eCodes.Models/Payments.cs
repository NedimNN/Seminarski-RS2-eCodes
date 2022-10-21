using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Payments
    {
        public string PaymentMethodNonce { get; set; }
        public string DeviceData { get; set; }
        public decimal Amount { get; set; }
        public int BuyerId { get; set; }
        public bool Successful { get; set; }
        public int ProductId { get; set; }
        public decimal UsedLoyaltyPoints { get; set; }

    }
}
