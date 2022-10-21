using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class RatingUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public int ProductId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int BuyerId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime Date { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }
        [Required(AllowEmptyStrings = false)]
        public decimal Mark { get; set; }
    }
}
