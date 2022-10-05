using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Currency
    {
        public Currency()
        {
            ProductTypes = new HashSet<ProductType>();
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;

        public virtual ICollection<ProductType> ProductTypes { get; set; }
    }
}
