﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class OutputSearchObject : BaseSearchObject
    {
        public string BuyerName { get; set; }
        public int OrderId { get; set; }

        public bool Include { get; set; }
    }
}
