using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Persons
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual Cities City { get; set; } 
        public string CityName => City?.Name;
        public string Jmbg { get; set; } 
        public string Gender { get; set; } 
    }
}
