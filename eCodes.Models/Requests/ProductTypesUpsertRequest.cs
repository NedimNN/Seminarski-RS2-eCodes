using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class ProductTypesUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Region { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int CurrencyId { get; set; }

    }
}
