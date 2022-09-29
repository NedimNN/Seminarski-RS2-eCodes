using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCodes.Models
{
    public partial class Users
    {
        public int UserId { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Username { get; set; } 
        public int PersonId { get; set; }
        public bool Status { get; set; }

        //public virtual Persons Person { get; set; }
        //public virtual ICollection<Output> Outputs { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
        public string RoleNames => string.Join(", ", UserRoles?.Select(s => s.Role?.Name)?.ToList());
    }
}
