using Braintree;
using eCodes.Models;
using eCodes.Models.SearchObjects;
using eCodes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCodes.Controllers
{
    [ApiController]
    [Route("Payment")]
    [Authorize]

    public class PaymentController : ControllerBase
    {
        public IPaymentService _paymentService { get; set; }
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("BeginTransaction")]
        public Payments BeginTransaction([FromBody]Payments payment)
        {
            var result = _paymentService.BeginTransaction(payment);
            return result;
        }
        [HttpPost("SaveTransaction")]
        public Orders SaveTransaction(int orderId,decimal loyaltyPoints)
        {
            var result = _paymentService.SaveTransaction(orderId,loyaltyPoints);
            return result;
        }

    }
}
