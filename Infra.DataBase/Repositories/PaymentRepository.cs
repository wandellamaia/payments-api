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

        public void Insert(PaymentDTO payment)
        {
            PaymentsData.payments.Add(new Money((float)1.0));
        }
    }
}