using Adapters;
using DTO;
using Entities;

namespace Infra.DataBase.Repositories
{

    public class PaymentRepository : IPaymentRepository
    {
        public IEnumerable<Payment> GetAllPayments()
        {
            return PaymentsData.payments;
        }

        public void Insert(Payment payment)
        {
            PaymentsData.payments.Add(payment);
        }
    }
}