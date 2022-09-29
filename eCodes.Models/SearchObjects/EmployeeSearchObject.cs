using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.SearchObjects
{
    public class EmployeeSearchObject: BaseSearchObject
    {
        public DateTime DateOfEmployement { get; set; }
        public int EmployeeNumber { get; set; }
        public bool IncludePerson { get; set; }

    }
}
