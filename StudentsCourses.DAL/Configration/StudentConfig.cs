using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsCourses.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.DAL.Configration
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.FullName)
                   .IsRequired();

            builder.Property(s => s.Email)
                   .IsRequired();

            builder.HasIndex(s => s.Email)
                   .IsUnique();

            builder.HasOne(s => s.Course)
                   .WithMany(c => c.Students)
                   .HasForeignKey(s => s.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
