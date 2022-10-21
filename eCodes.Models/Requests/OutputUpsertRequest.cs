using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class OutputUpsertRequest
    {
        public DateTime Date { get; set; }
        public string PaymentMethod { get; set; }
        public int BuyerId { get; set; }
        public bool Concluded { get; set; }
        public decimal AmountWithTax { get; set; }
        public int OrderId { get; set; }
        public string ReceiptNumber { get; set; }
        public decimal AmountWithoutTax { get; set; }
    }
}
