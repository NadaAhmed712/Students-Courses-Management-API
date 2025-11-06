using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCourses.DAL.Entity;

namespace StudentsCourses.DAL.Configration
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired();
            builder.Property(c => c.Level)
                   .HasConversion<string>()
                   .HasMaxLength(20);
            builder.HasMany(c=>c.Students).WithOne(s=>s.Course)
                   .HasForeignKey(s=>s.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
