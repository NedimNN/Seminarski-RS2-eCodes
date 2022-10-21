using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class PersonInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CityName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Jmbg { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Gender { get; set; }
    }
}
