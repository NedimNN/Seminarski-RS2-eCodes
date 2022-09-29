using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class UserInsertRequest
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
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Phone()]
        public string PhoneNumber { get; set; }
        [MinLength(4)]
        [Required(AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
        public int PersonId { get; set; }
        public bool Status { get; set; }
        public List<int> UserRolesIdList { get; set; } = new List<int> { };
    }
}
