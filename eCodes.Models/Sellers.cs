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
        public string PayPalEmail { get; set; }


        public virtual Persons Person { get; set; }

        public string Firstname => Person?.FirstName;
        public string Lastname => Person?.LastName;

    }
}
