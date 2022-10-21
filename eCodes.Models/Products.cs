using System;
using System.Linq;


namespace eCodes.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int ProductTypeId { get; set; }
        public byte[] Picture { get; set; }
        public byte[] PictureThumb { get; set; }
        public string StateMachine { get; set; } 
        public string Description { get; set; }
        public string Duration { get; set; } 
        public int Value { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public virtual ProductTypes ProductType { get; set; }
        public string ProductTypeName => ProductType?.Name + ", " + ProductType?.Region;
        public string GiftCardKey { get; set; }
        public int SellerId { get; set; }
        public string SellerName => Seller?.Name;
        public virtual Sellers Seller { get; set; }

    }
}
