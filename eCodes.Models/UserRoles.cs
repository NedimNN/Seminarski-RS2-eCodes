using System;
using System.Collections.Generic;

namespace eCodes.Models
{
    public partial class UserRoles
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime Date { get; set; }
        public virtual Roles Role { get; set; }
    }
}
