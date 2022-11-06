using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class NotificationUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string NotificationDesc { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime NotificationDateTime { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int BuyerId { get; set; }

    }
}
