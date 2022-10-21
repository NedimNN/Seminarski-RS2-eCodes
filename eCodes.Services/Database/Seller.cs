using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Seller
    {
        public Seller()
        {
            OutputItems = new HashSet<OutputItem>();
            Products = new HashSet<Product>();
        }

        public int SellerId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Website { get; set; }
        public string Email { get; set; } = null!;
        public int PersonId { get; set; }
        public bool Status { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string PayPalEmail { get; set; } = null!;

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<OutputItem> OutputItems { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
