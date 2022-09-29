using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Person
    {
        public Person()
        {
            Buyers = new HashSet<Buyer>();
            Employees = new HashSet<Employee>();
            Sellers = new HashSet<Seller>();
            Users = new HashSet<User>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public int CityId { get; set; }
        public string Jmbg { get; set; } = null!;
        public string Gender { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
