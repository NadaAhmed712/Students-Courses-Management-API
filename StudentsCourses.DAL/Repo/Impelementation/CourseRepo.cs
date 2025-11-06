using StudentsCourses.DAL.Database;
using StudentsCourses.DAL.Entity;
using StudentsCourses.DAL.Repo.Abstraction;

namespace StudentsCourses.DAL.Repo.Impelementation
{
    public class CourseRepo:ICourseRepo
    {
        private readonly StudentsCoursesDbContext _context;
        public CourseRepo(StudentsCoursesDbContext context)
        {
            _context = context;
        }
        public bool Add(Course course)
        {
            try
            {
                var result = _context.Courses.Add(course);
                _context.SaveChanges();
                if (result.Entity.Id != null)
                    return true;
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(Course course)
        {
            try
            {
                var result = _context.Courses.FirstOrDefault(e => e.Id == course.Id);
                if (result != null)
                {
                    _context.Courses.Remove(result);
                    _context.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Edit(Course course)
        {
            try
            {
                var result = _context.Courses.FirstOrDefault(e => e.Id == course.Id);
                if (result != null)
                {
                    bool flag = result.Update(course.Name, course.Description, course.Level);
                    if (flag)
                        _context.SaveChanges();
                    return flag;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Course> GetAll()
        {
            try
            {
                var result = _context.Courses.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Course GetCourseById(int id)
        {
            try
            {
                var result = _context.Courses.FirstOrDefault(e => e.Id == id);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
