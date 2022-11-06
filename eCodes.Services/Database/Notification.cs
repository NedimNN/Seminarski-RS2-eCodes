using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationDesc { get; set; } = null!;
        public DateTime NotificationDateTime { get; set; }
        public int BuyerId { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
    }
}
