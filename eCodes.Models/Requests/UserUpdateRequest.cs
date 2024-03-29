﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class UserUpdateRequest
    {
        //PersonUpdateRequest
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public DateTime DateOfBirth { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Gender { get; set; }
        //----------------------------------
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public bool Status { get; set; }
        public List<int> UserRolesIdList { get; set; } = new List<int> { };

    }
}
