using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Outputs
    {
        public int OutputId { get; set; }
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public int BuyerId { get; set; }
        public bool Concluded { get; set; }
        public decimal AmountWithTax { get; set; }
        public int OrderId { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal AmountWithoutTax { get; set; }
        public string FirstName => Buyer?.Person.FirstName;
        public string LastName => Buyer?.Person.LastName;
        public virtual Buyers Buyer { get; set; }
        public virtual ICollection<OutputItems> OutputItems { get; set; }

    }
}
