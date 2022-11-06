using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Buyer
    {
        public Buyer()
        {
            LoyaltyPoints = new HashSet<LoyaltyPoint>();
            Notifications = new HashSet<Notification>();
            Orders = new HashSet<Order>();
            Outputs = new HashSet<Output>();
            Ratings = new HashSet<Rating>();
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
        public virtual ICollection<LoyaltyPoint> LoyaltyPoints { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Output> Outputs { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
