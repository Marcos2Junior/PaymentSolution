using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;

namespace PaymentSolution.Infrastructure.Repositories
{
    public class PaymentRepository : PaymentSolutionRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PaymentSolutionDataContext paymentSolutionDataContext) : base(paymentSolutionDataContext)
        {
        }
    }
}
