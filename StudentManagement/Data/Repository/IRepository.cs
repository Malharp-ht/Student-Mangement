


using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
   
 public interface IRepository<TEntity> 
        {
            Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter, bool useNoTracking = false);
            Task<List<TEntity>> GetAllAsync();
            Task<TEntity> AddAsync(TEntity entity);
            Task<TEntity> UpdateAsync(TEntity entity);
            Task<bool> DeleteAsync(TEntity entity);
            //Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, bool useNoTracking = false);
    }
    }

