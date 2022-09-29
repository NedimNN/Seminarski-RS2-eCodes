using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class RatingUpsertRequest
    {
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Mark { get; set; }
    }
}
