using DotNetApplication.Data;
using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
    public interface IEnrollementRepository : IRepository<Enrollement>
    {
        Task<List<Enrollement>> GetAllGetEnrolledCoursesAsync(Expression<Func<Enrollement, bool>> filter, bool useNoTracking = false);
    }
}
