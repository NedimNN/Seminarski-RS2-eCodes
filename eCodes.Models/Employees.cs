using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public bool Status { get; set; }    
        public int EmployeeNumber { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        //public string PasswordHash { get; set; }
        //public string PasswordSalt { get; set; }

        public virtual Persons Person { get; set; }

        public string Firstname => Person?.FirstName;
        public string Lastname => Person?.LastName;
        public string JMBG => Person?.Jmbg;
        public string Gender => Person?.Gender;
        public string CityName => Person?.CityName;


    }
}
