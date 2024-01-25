using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetApplication.Data.Config
{
    public class enrollementConfig : IEntityTypeConfiguration<Enrollement>
    {
        public void Configure(EntityTypeBuilder<Enrollement> builder)
        {
            builder.HasKey(e => e.enrollementId);
            builder.Property(e => e.studentId).IsRequired();
            builder.Property(e => e.courseId).HasMaxLength(2);

            builder.HasOne(e => e.Student)
                .WithMany(s => s.Enrollements)
                .HasForeignKey(e => e.studentId);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollements)
                .HasForeignKey(e => e.courseId);


        }
    }
}
