using Adapters;
using Domain.Services;
using DTO;
using Entities;

namespace Services.Manager
{
    public class PaymentManager : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public IEnumerable<PaymentDTO> RecoverAllChecksPayments()
        {
            List<PaymentDTO> allPayments = new List<PaymentDTO>();
            allPayments.AddRange(GetAllCheckPayments());

            return allPayments;
        }
        public IEnumerable<PaymentDTO> RecoverAllPayments()
        {
            List<PaymentDTO> allPayments = new List<PaymentDTO>();
            allPayments.AddRange(GetAllCheckPayments());

            return allPayments;
        }
        private IEnumerable<PaymentDTO> GetAllCheckPayments()
        {
            List<Payment> checksList = _paymentRepository.GetAllPayments().ToList();
            List<PaymentDTO> payments = new List<PaymentDTO>();

            foreach (var check in checksList)
            {
                payments.Add(new PaymentDTO
                {
                    PaymentType = check.Type(),
                    Value = check.Value()
                });
            }
            return payments;
        }

        public void RegisterPayment(PaymentDTO paymentCheck)
        {
            _paymentRepository.Insert(paymentCheck);
        }
    }
}