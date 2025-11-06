using StudentsCourses.DAL.Entity;
using System.Linq.Expressions;

namespace StudentsCourses.DAL.Repo.Abstraction
{
    public interface ICourseRepo
    {
        bool Add(Course course);
        bool Edit(Course course);
        bool Delete(Course course);
        Course GetCourseById(int id);
        List<Course> GetAll();
    }
}
