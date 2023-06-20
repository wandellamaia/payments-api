using DTO;
using Entities;

namespace Adapters
{
    public interface IPaymentRepository
    {
        public IEnumerable<Payment> GetAllPayments();
        public void Insert(Payment payment);
    }
}