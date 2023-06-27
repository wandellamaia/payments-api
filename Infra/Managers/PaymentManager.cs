using Adapters;
using DTO;
using Entities;
using Services;
using System.Collections.Generic;

namespace Infra.Managers
{
    public class PaymentManager : IPaymentServices
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentManager(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public IEnumerable<PaymentDTO> RecoverAllPayments()
        {
            List <PaymentDTO> allPayments = new List<PaymentDTO>();
            allPayments.AddRange(GetAllCheckPayments());

            return allPayments;
        }
        private IEnumerable<PaymentDTO> GetAllCheckPayments()
        {
            List<Check> checksList = _paymentRepository.GetAllPaymentsCheck().ToList();
            List<PaymentDTO> payments = new List<PaymentDTO>();

            foreach (var check in checksList)
            {
                payments.Add(new PaymentDTO
                {
                    PaymentType = check._paymentType,
                    Value = check._quantity
                });
            }
            return payments;
        }

        public Task<int> RegisterAPayment(Check paymentCheck)
        {
            return Task.FromResult(0);
        }
    }
}