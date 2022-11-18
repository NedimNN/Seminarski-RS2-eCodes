using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
            Outputs = new HashSet<Output>();
        }

        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = null!;
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public bool? Canceled { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Output> Outputs { get; set; }
    }
}
