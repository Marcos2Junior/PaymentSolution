using Microsoft.EntityFrameworkCore;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;
using PaymentSolution.Shared.Enums;

namespace PaymentSolution.Infrastructure.Repositories
{
    public class PaymentServiceRepository : PaymentSolutionRepository<PaymentService>, IPaymentServiceRepository
    {
        public PaymentServiceRepository(PaymentSolutionDataContext paymentSolutionDataContext) : base(paymentSolutionDataContext)
        {
        }

        public async Task<PaymentService> GetPaymentServiceAsync(int userId, PaymentServiceType paymentServiceType)
        {
            return await dbSet.FirstOrDefaultAsync(x => x.UserID == userId && x.PaymentServiceType == paymentServiceType);
        }
    }
}
