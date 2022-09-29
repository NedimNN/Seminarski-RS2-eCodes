﻿using System;
using System.Collections.Generic;

namespace eCodes.Services.Database
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public int PersonId { get; set; }
        public DateTime DateOfEmployement { get; set; }
        public bool Status { get; set; }
        public int EmployeeNumber { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;

        public virtual Order? Order { get; set; }
        public virtual Person Person { get; set; } = null!;
        public virtual Product? Product { get; set; }
    }
}
