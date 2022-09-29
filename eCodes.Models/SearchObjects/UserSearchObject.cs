using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class UserSearchObject : BaseSearchObject
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }

        public bool IncludeRoles { get; set; }

    }
}
