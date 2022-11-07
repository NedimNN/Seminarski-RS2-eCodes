using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using eCodes;
using eCodes.Services.Database;
using Microsoft.EntityFrameworkCore;

namespace eCodes.Services.HelperMethods
{
    public static class LoginHelper
    {
        public static int ID { get; set; }
        public static string AccountType { get; set; }

    }
}
