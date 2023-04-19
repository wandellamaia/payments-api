using Adapters;
using Entities;
using Services;

namespace Infra.Managers
{
    public class PaymentManager : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public IEnumerable<Check> RecoverAllPayments()
        {
            return _paymentRepository.GetAllPaymentsCheck().ToList();
        }

        public Task<int> RegisterAPayment(Check paymentCheck)
        {
            return Task.FromResult(0);
        }
    }
}