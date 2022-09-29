﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Requests
{
    public class UserUpdateRequest
    {
        //PersonUpdateRequest
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        //----------------------------------
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
