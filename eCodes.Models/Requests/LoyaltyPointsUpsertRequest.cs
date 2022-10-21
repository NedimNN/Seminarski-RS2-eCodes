using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class LoyaltyPointsUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public decimal Balance { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int BuyerId { get; set; }
    }
}
