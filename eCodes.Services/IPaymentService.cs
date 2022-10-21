using Braintree;
using eCodes.Models;
using eCodes.Models.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCodes.Services
{
    public interface IPaymentService
    {
        Payments BeginTransaction(Payments payment);
        Orders SaveTransaction(int orderId, decimal loyaltyPoints);

    }
}
