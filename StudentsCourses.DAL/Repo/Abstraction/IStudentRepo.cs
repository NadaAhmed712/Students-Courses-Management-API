using StudentsCourses.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.DAL.Repo.Abstraction
{
    public interface IStudentRepo
    {
        bool Add(Student student);
        bool Edit(Student student);
        bool Delete(Student student);
        Student GetStudentById(int id);
        List<Student> GetAll();
    }
}
