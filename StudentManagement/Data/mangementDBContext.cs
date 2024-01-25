using DotNetApplication.Data.Config;
using DotNetApplication.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Data
{
    public class mangementDBContext : DbContext
    {
        public mangementDBContext(DbContextOptions<mangementDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollement> Enrollements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new studentConfig());
            modelBuilder.ApplyConfiguration(new courseConfig());
            modelBuilder.ApplyConfiguration(new enrollementConfig());
        }
    }
}
