using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCodes.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public bool? Canceled { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual Buyers Buyer { get; set; }
        public string Price => OrderItems?.Select(s => Convert.ToDecimal(s.Price)).Sum().ToString();
        public string BuyerName => Buyer?.Username;
    }
}
