using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Sellers
    {
        public int SellerId { get; set; }
        public string Name { get; set; }  
        public string Address { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Website { get; set; }
        public string Email { get; set; } 
        public int PersonId { get; set; }
        public bool Status { get; set; }
        //public string PasswordHash { get; set; }
        //public string PasswordSalt { get; set; }

        //public virtual Person Person { get; set; } = null!;
        //public virtual ICollection<Output> Outputs { get; set; }
        //public virtual ICollection<Product> Products { get; set; }
    }
}
