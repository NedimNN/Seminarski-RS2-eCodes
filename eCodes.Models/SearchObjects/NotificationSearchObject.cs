using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class NotificationSearchObject : BaseSearchObject
    {
        public int BuyerId { get; set; }
        public bool IncludeBuyer  { get; set; }

    }
}
