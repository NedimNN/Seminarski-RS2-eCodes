using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Currency
    {
        public Currency()
        {
            Wallets = new HashSet<Wallet>();
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;

        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
