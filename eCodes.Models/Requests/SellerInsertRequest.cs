﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eCodes.Models.Requests
{
    public class SellerInsertRequest
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
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        public int PersonId { get; set; }
        public bool Status { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PasswordConfirmation { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string PayPalEmail { get; set; }

    }
}
