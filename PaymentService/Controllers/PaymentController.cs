using Domain.Services;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentServices _paymentServices;

        private readonly ILogger<PaymentController> _logger;

        public PaymentController(ILogger<PaymentController> logger, IPaymentServices paymentServices)
        {
            _logger = logger;
            _paymentServices = paymentServices;
        }
        [HttpGet(Name = "GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            _logger.LogInformation("Started application");
            IEnumerable<PaymentDTO> payments = _paymentServices.RecoverAllPayments();
            _logger.LogInformation("Finished application");
            return Ok(payments);
        }

        [HttpPost(Name = "SetPayment")]
        public void SetPayment(PaymentDTO payment)
        {
            _paymentServices.RegisterPayment(payment);
        }
    }
}