﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class SellerSearchObject : BaseSearchObject
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public bool IncludePerson { get; set; }


    }
}
