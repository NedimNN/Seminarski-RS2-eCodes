using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class CountryUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

    }
}
