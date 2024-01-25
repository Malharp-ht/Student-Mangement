using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetApplication.Data.Config
{
    public class studentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(x => x.studentId);

            builder.Property(x => x.studentId).UseIdentityColumn();

            builder.Property(n => n.StudentName).IsRequired();
            builder.Property(n => n.StudentName).HasMaxLength(250);
            builder.Property(n => n.Address).IsRequired(false).HasMaxLength(500);
            builder.Property(n => n.Email).IsRequired().HasMaxLength(250);

            builder.HasData(new List<Student>()
            {
                new Student
                {
                    studentId = 1,
                    StudentName = "Malhar",
                    Address = "Baramati",
                    DOB = new DateTime(2024, 12, 12),
                    Email = "malharp@gmail.com"
                },
                new Student
                 {
                     studentId = 2,
                     StudentName = "Mohit",
                     Address = "Satara",
                     DOB = new DateTime(2024, 12, 12),
                     Email = "mohitl@gmail.com"
                 }

            });


        }
    }
}
