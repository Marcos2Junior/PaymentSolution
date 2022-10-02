using Microsoft.EntityFrameworkCore;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;

namespace PaymentSolution.Infrastructure.Repositories
{
    public class UserAccessRepository : PaymentSolutionRepository<UserAccess>, IUserAccessRepository
    {
        public UserAccessRepository(PaymentSolutionDataContext dbContext) : base(dbContext)
        {
        }
    }
}
