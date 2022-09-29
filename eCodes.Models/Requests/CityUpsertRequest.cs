using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class CityUpsertRequest
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

    }
}
