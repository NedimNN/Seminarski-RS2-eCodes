using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Output
    {
        public Output()
        {
            OutputItems = new HashSet<OutputItem>();
        }

        public int OutputId { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentMethod { get; set; }
        public int BuyerId { get; set; }
        public bool Concluded { get; set; }
        public decimal AmountWithTax { get; set; }
        public int OrderId { get; set; }
        public string ReceiptNumber { get; set; } = null!;
        public decimal AmountWithoutTax { get; set; }

        public virtual Buyer Buyer { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<OutputItem> OutputItems { get; set; }
    }
}
