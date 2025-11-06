using StudentsCourses.DAL.Database;
using StudentsCourses.DAL.Entity;
using StudentsCourses.DAL.Repo.Abstraction;

namespace StudentsCourses.DAL.Repo.Impelementation
{
    public class StudentRepo:IStudentRepo
    {
        private readonly StudentsCoursesDbContext _context;
        public StudentRepo(StudentsCoursesDbContext context)
        {
            _context = context;
        }
        public bool Add(Student student)
        {
            try
            {
                var result = _context.Students.Add(student);
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

        public bool Delete(Student student)
        {
            try
            {
                var result = _context.Students.FirstOrDefault(e => e.Id == student.Id);
                if (result != null)
                {
                    _context.Students.Remove(result);
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

        public bool Edit(Student student)
        {
            try
            {
                var result = _context.Students.FirstOrDefault(e => e.Id == student.Id);
                if (result != null)
                {
                    bool flag = result.Update(student.FullName,student.Email,student.EnrollmentDate, student.CourseId);
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

        public List<Student> GetAll()
        {
            try
            {
                var result = _context.Students.ToList();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Student GetStudentById(int id)
        {
            try
            {
                var result = _context.Students.FirstOrDefault(e => e.Id == id);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
