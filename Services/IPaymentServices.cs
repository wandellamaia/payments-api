using DTO;

namespace Domain.Services
{
    public interface IPaymentServices
    {
        IEnumerable<PaymentDTO> RecoverAllPayments();
        void RegisterPayment(PaymentDTO payment);
    }
}