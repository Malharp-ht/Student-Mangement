using DotNetApplication.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StudentManagement.Data.Repository
{
    public class StudentRepository : Repository<Student> ,IStudentRepository
    {
        private readonly mangementDBContext _dbContext;
        public StudentRepository(mangementDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
