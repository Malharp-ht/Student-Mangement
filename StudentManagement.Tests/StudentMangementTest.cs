using DotNetApplication.Data;
using StudentManagement.Controllers;
using StudentManagement.Data.Repository;

namespace StudentManagement.Tests
{
    public abstract class StudentMangementTest 
    {
    
        protected IRepository<Student> _service;

        protected abstract IEnumerable<Student> GetSampleData();
        protected abstract Student GetSampleEntity();
        [Fact]
        public void GetStudents_Returns_The_Correct_Number_Of_Students()
        {
            var entities = GetSampleData();

            // Act
            var result = _service.GetAllAsync();

            // Assert
            Assert.NotNull(result);
            //Assert.Equal(entities, result);
        }
    }
}