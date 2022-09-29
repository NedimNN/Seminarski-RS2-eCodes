using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class PersonUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}
