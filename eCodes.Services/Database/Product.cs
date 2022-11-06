using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Product
    {
        public Product()
        {
            Employees = new HashSet<Employee>();
            OrderItems = new HashSet<OrderItem>();
            OutputItems = new HashSet<OutputItem>();
            Ratings = new HashSet<Rating>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public decimal Price { get; set; }
        public string GiftCardKey { get; set; } = null!;
        public int ProductTypeId { get; set; }
        public byte[]? Picture { get; set; }
        public byte[]? PictureThumb { get; set; }
        public string StateMachine { get; set; } = null!;
        public string? Description { get; set; }
        public string Duration { get; set; } = null!;
        public int Value { get; set; }
        public string? Version { get; set; }
        public string? Platform { get; set; }
        public int? SellerId { get; set; }

        public virtual ProductType ProductType { get; set; } = null!;
        public virtual Seller? Seller { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<OutputItem> OutputItems { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
