using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Exceptions
{
    public class UserErrorException : Exception
    {
        public UserErrorException(string message) : base(message)
        {

        }

    }
}
