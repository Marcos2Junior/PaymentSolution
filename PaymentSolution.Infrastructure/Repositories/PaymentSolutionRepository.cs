using Microsoft.EntityFrameworkCore;
using PaymentSolution.Domain.Entities;
using PaymentSolution.Infrastructure.Interfaces.Repositories;

namespace PaymentSolution.Infrastructure.Repositories
{
    public class PaymentSolutionRepository<TEntity> : IPaymentSolutionRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> dbSet;

        public PaymentSolutionRepository(DbContext dbContext)
        {
            _context = dbContext;
            dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity obj)
        {
            var r = await dbSet.AddAsync(obj);
            await CommitAsync();
            return r.Entity;
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return await CommitAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            TEntity entity = await GetByIdAsync(id);

            if (entity == null) return false;

            return await RemoveAsync(entity) > 0;
        }

        public async Task<int> RemoveAsync(TEntity obj)
        {
            dbSet.Remove(obj);
            return await CommitAsync();
        }

        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
            return await CommitAsync();
        }

        public async Task<int> UpdateAsync(TEntity obj)
        {
            var avoidingAttachedEntity = await GetByIdAsync(obj.Id);
            _context.Entry(avoidingAttachedEntity).State = EntityState.Detached;

            var entry = _context.Entry(obj);
            if (entry.State == EntityState.Detached) _context.Attach(obj);

            _context.Entry(obj).State = EntityState.Modified;
            return await CommitAsync();
        }

        public async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
            return await CommitAsync();
        }

        private async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
