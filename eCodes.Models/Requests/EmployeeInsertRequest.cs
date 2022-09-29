using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class EmployeeInsertRequest
    {
        //PersonInsertRequest
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string CityName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Jmbg { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Gender { get; set; }
        //-----------------------------------------
        public int PersonId { get; set; }
        public bool Status { get; set; }
        public DateTime DateOfEmployement { get; set; }
        [Required(AllowEmptyStrings = false)]
        public int EmployeeNumber { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
    }
}
