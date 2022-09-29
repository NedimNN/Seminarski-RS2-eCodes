using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Buyers
    {
        public int BuyerId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Email { get; set; }
        public string Username { get; set; } 
        public int PersonId { get; set; }
        public bool Status { get; set; }

        public virtual Persons Person { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        //public virtual ICollection<Rating> Ratings { get; set; }
        //public virtual ICollection<Wallet> Wallets { get; set; }
    }
}
