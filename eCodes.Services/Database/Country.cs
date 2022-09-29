using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }
    }
}
