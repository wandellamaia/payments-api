using Entities;

namespace Services
{
    public interface IPaymentServices
    {
        IEnumerable<Check> RecoverAllPayments();

        Task<int> RegisterAPayment(Check paymentCheck);
    }
}