using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class WalletUpsertRequest
    {
        public decimal Balance { get; set; }
        public int CurrencyId { get; set; }
        public int BuyerId { get; set; }
    }
}
