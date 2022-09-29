using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class BuyersSearchObject : BaseSearchObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public bool IncludePerson { get; set; }
    }
}
