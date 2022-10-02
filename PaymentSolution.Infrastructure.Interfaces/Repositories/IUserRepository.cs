using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.Interfaces.Repositories
{
    public interface IUserRepository : IPaymentSolutionRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
