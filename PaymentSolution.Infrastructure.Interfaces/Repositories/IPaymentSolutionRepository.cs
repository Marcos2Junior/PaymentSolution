using PaymentSolution.Domain.Entities;

namespace PaymentSolution.Infrastructure.Interfaces.Repositories
{
    public interface IPaymentSolutionRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<int> UpdateAsync(TEntity obj);
        Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

        Task<bool> RemoveAsync(int id);
        Task<int> RemoveAsync(TEntity obj);
        Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
