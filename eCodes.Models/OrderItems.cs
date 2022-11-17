using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class OrderItems
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }

        public string Name => Product?.Name;
        public string Code => Product?.Code;
        public string Type => Product?.ProductTypeName;
        public string Description => Product?.Description;
        public string Value => Product?.Value.ToString();
        public string Price => Product?.Price.ToString();
        public string SellerName => Product?.SellerName;

    }
}
