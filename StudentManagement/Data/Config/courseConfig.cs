using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetApplication.Data.Config
{
    public class courseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(x => x.courseId);

            builder.Property(x => x.courseId).UseIdentityColumn();

            builder.Property(n => n.courseName).IsRequired().HasMaxLength(200);
            builder.Property(n => n.courseDescription).HasMaxLength(500).IsRequired(false);

            builder.HasData(new List<Course>()
            {
                new Course
                {
                    courseId = 1,
                    courseName = "ECE",
                    courseDescription = "ECE",

                },
                new Course
                 {
                     courseId = 2,
                     courseName = "CSE",
                     courseDescription = "CSE",
                 }

            });
        }
    }
}
