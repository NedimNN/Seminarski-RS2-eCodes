﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eCodes.Models.Exceptions
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {

        }

    }
}
