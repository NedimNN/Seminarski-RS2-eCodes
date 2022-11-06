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
        public static string Username { get; set; }
        public static string AccountType { get; set; }
        public static string Connection { get; set; }
   
        public static string GetAccType(string username)
        {
            var _context = new _210331Context();

            var employee = _context.Employees.Where(w => w.EmployeeNumber.ToString() == username).FirstOrDefault();
            var user = _context.Users.Where(w => w.Username == username).Include("UserRoles.Role").FirstOrDefault();
            var seller = _context.Sellers.Where(w => w.Name == username).FirstOrDefault();
            var buyer = _context.Buyers.Where(w => w.Username == username).FirstOrDefault();

            if (employee != null)
            {
                AccountType = "Employee";
            }
            else if(user != null)
            {
                var userRoles = user.UserRoles;
                foreach(var role in userRoles)
                {
                    AccountType += role.Role.Name + ", ";
                }
            }
            else if(seller != null)
            {
                AccountType = "Seller";
            }
            else if(buyer != null)
            {
                AccountType = "Buyer";
            }

            return AccountType;
        }


    }
}
