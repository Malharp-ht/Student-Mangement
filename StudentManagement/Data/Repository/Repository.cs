using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly mangementDBContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public Repository(mangementDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter, bool useNoTracking = false)
        {
            if (useNoTracking)
                return await _dbSet.AsNoTracking().Where(filter).FirstOrDefaultAsync();
            else
                return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
