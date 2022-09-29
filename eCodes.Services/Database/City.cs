using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class City
    {
        public City()
        {
            People = new HashSet<Person>();
        }

        public int CityId { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Person> People { get; set; }
    }
}
