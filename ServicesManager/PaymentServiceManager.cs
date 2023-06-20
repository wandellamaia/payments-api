using Adapters;
using Domain.Services;
    using DTO;
    using Entities;

namespace ServicesManager
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
                        PaymentType = check.GetType().Name,
                        Value = check.Value()
                    });
                }
                return payments;
            }

            public void RegisterPayment(PaymentDTO paymentCheck)
            {
                Payment payment = new Money(0);

                switch (paymentCheck.PaymentType)
                {
                case PaymentTypes.CHECK:
                    payment = new Check(paymentCheck.Value);
                    break;
                case PaymentTypes.MONEY : payment = new Money(paymentCheck.Value);
                    break;
                default: payment = new Money(paymentCheck.Value);
                    break;
                }

                _paymentRepository.Insert(payment);
            }
        }
    }
