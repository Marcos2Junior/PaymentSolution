using PaymentSolution.Domain.Entities;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Infrastructure.Interfaces.Repositories
{
    public interface IPaymentServiceRepository : IPaymentSolutionRepository<PaymentService>
    {
        Task<PaymentService> GetPaymentServiceAsync(int userId, PaymentServiceType paymentServiceType);
    }
}
