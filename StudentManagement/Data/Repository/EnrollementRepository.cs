using DotNetApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
    public class EnrollementRepository : Repository<Enrollement>,IEnrollementRepository
    {
        private readonly mangementDBContext _dbContext;
        private DbSet<Enrollement> _dbSet;
        public EnrollementRepository(mangementDBContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Enrollement>();
        }

        public async Task<List<Enrollement>> GetAllGetEnrolledCoursesAsync(Expression<Func<Enrollement, bool>> filter, bool useNoTracking = false)
        {
            if (useNoTracking)
                return await _dbSet.AsNoTracking().Where(filter).ToListAsync();
            else
                return await _dbSet.Where(filter).ToListAsync();
        }
    }
}
