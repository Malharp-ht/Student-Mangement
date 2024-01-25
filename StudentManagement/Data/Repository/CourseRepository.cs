using DotNetApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly mangementDBContext _dbContext;
        private DbSet<Course> _dbSet;
        public CourseRepository(mangementDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Course>();

        }

        public List<Course> GetStudentCourses(int studentId)
        {
            var courseIds = _dbContext.Enrollements
            .Where(e => e.studentId == studentId)
            .Select(e => e.courseId)
            .ToList();

            var courses = _dbContext.Courses
                .Where(c => courseIds.Contains(c.courseId))
                .ToList();

            return courses;
        }
    }
}
