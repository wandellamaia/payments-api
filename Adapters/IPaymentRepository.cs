using Entities;

namespace Adapters
{
    public interface IPaymentRepository
    {
        public Task<IEnumerable<Payment>> GetAll();
        public IEnumerable<Check> GetAllPaymentsCheck();
        public Task<int> Insert(Payment payment);
    }
}