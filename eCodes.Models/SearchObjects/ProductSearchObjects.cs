using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class ProductSearchObjects : BaseSearchObject
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public int Value { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string SellerName { get; set; }
        public bool IncludeType { get; set; }
        public string StateMachine { get; set; }


    }
}
