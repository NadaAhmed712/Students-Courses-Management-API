using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsCourses.DAL.Entity;

namespace StudentsCourses.DAL.Database
{
    public class StudentsCoursesDbContext : IdentityDbContext<IdentityUser>
    {
        public StudentsCoursesDbContext(DbContextOptions<StudentsCoursesDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
