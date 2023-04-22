using DTO;
using Entities;

namespace Services
{
    public interface IPaymentServices
    {
        IEnumerable<PaymentDTO> RecoverAllPayments();

        Task<int> RegisterAPayment(Check paymentCheck);
    }
}