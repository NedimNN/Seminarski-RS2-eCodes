﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class OrderSearchObject : BaseSearchObject
    {
        public string OrderNumber { get; set; }
        public string BuyerName { get; set; }
        public DateTime Date { get; set; }
        public bool? Canceled { get; set; }

        public bool IncludeItems { get; set; }
        public bool IncludeBuyer { get; set; }
    }
}
