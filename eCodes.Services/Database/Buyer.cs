using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Buyer
    {
        public Buyer()
        {
            Orders = new HashSet<Order>();
            Ratings = new HashSet<Rating>();
            Wallets = new HashSet<Wallet>();
        }

        public int BuyerId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public int PersonId { get; set; }
        public bool Status { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
