using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Wallet
    {
        public int WalletId { get; set; }
        public decimal Balance { get; set; }
        public int CurrencyId { get; set; }
        public int BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Currency Currency { get; set; } = null!;
    }
}
