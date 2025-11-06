using AutoMapper;
using StudentsCourses.BLL.Dto.Student;
using StudentsCourses.BLL.ResponseResult;
using StudentsCourses.BLL.Services.Abstraction;
using StudentsCourses.DAL.Entity;
using StudentsCourses.DAL.Repo.Abstraction;

namespace StudentsCourses.BLL.Services.Impelementation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepo courseRepo, IMapper mapper)
        {
            _studentRepo = courseRepo;
            _mapper = mapper;
        }
        public Response<bool> Add(CreateStudentDTO student)
        {
            try
            {

                var newStudent = new Student(student.FullName,student.Email,student.EnrollmentDate,student.CourseId);
                var result = _studentRepo.Add(newStudent);
                if (result)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "there is an error", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
        }

        public Response<bool> Delete(int id)
        {
            try
            {
                var result = _studentRepo.GetStudentById(id);
                if (result == null)

                    return new Response<bool>(false, "There is no Student with this Id", true);
                _studentRepo.Delete(result);

                return new Response<bool>(true, null, false);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
        }

        public Response<bool> Edit(UpdateStudentDTO student)
        {
            try
            {
                var map = _mapper.Map<Student>(student);

                var flag = _studentRepo.Edit(map);
                if (flag)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "Failed to update Student.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }

        public Response<GetStudentDTO> GetStudent(int id)
        {
            try
            {
                var result = _studentRepo.GetStudentById(id);
                if (result == null)

                    return new Response<GetStudentDTO>(null, "There is no Student with this Id", true);
                var resultVM = _mapper.Map<GetStudentDTO>(result);

                return new Response<GetStudentDTO>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<GetStudentDTO>(null, ex.Message, true);

            }
        }

        public Response<List<GetStudentDTO>> GetStudents()
        {
            try
            {
                var result = _studentRepo.GetAll();
                var resultDTO = _mapper.Map<List<GetStudentDTO>>(result);
                return new Response<List<GetStudentDTO>>(resultDTO, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetStudentDTO>>(null, ex.Message, true);

            }
        }
    }
}
