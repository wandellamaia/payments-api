using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger, IPaymentServices paymentServices)
        {
            _logger = logger;
            _paymentServices = paymentServices;
        }

        [HttpGet(Name = "GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            IEnumerable<Check> payments = _paymentServices.RecoverAllPayments();
            return Ok(payments);
        }
    }
}