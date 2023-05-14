using DTO;
using Entities;

namespace Services
{
    public interface IPaymentServices
    {
        IEnumerable<PaymentDTO> RecoverAllPayments();
        void RegisterPayment(PaymentDTO payment);
    }
}