using AutoMapper;
using StudentsCourses.BLL.Dto.Course;
using StudentsCourses.BLL.Dto.Student;
using StudentsCourses.DAL.Entity;

namespace StudentsCourses.BLL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            CreateMap<Student, GetStudentDTO>().ReverseMap();
            CreateMap<Student, CreateStudentDTO>().ReverseMap();
            CreateMap<Student, UpdateStudentDTO>().ReverseMap();
            CreateMap<Course, GetCourseDTO>().ReverseMap();
            CreateMap<Course, CreateCourseDTO>().ReverseMap();
            CreateMap<Course, UpdateCourseDTO>().ReverseMap();
        }
    }
}
