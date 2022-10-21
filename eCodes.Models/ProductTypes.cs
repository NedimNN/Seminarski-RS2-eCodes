using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class ProductTypes
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; } 
        public string Region { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currencies Currency { get; set; }


    }
}
