using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Notifications
    {
        public int NotificationId { get; set; }
        public string NotificationDesc { get; set; } 
        public DateTime NotificationDateTime { get; set; }
        public int BuyerId { get; set; }

        public virtual Buyers Buyer { get; set; }
    }
}
