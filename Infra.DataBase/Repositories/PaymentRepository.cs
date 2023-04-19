using Adapters;
using Entities;

namespace Infra.DataBase.Repositories
{

    public class PaymentRepository : IPaymentRepository
    {
        public Task<IEnumerable<Payment>> GetAll()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Check> GetAllPaymentsCheck()
        {
            return PaymentsData.checks;
        }

        public Task<int> Insert(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}