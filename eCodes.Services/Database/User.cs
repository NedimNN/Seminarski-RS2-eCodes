using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class User
    {
        public User()
        {
            Outputs = new HashSet<Output>();
            UserRoles = new HashSet<UserRole>();
        }

        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public int PersonId { get; set; }
        public bool Status { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<Output> Outputs { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
