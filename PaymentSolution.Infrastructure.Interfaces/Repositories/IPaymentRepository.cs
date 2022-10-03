using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.Interfaces.Repositories
{
    public interface IPaymentRepository : IPaymentSolutionRepository<Payment>
    {
    }
}
