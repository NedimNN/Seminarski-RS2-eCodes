using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
