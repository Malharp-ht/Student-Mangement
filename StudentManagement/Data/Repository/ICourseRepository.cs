using DotNetApplication.Data;

namespace StudentManagement.Data.Repository
{
    public interface ICourseRepository : IRepository<Course>
    {
         List<Course> GetStudentCourses(int studentId);
   
    }
}
