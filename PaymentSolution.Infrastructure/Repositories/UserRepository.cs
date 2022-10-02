using Microsoft.EntityFrameworkCore;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;

namespace PaymentSolution.Infrastructure.Repositories
{
    public class UserRepository : PaymentSolutionRepository<User>, IUserRepository
    {
        public UserRepository(PaymentSolutionDataContext paymentSolutionDataContext) : base(paymentSolutionDataContext)
        {
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
