using StudentsCourses.BLL.Dto.Student;
using StudentsCourses.BLL.ResponseResult;

namespace StudentsCourses.BLL.Services.Abstraction
{
    public interface IStudentService
    {
        Response<bool> Add(CreateStudentDTO student);
        Response<bool> Edit(UpdateStudentDTO student);
        Response<bool> Delete(int id);
        Response<GetStudentDTO> GetStudent(int id);
        Response<List<GetStudentDTO>> GetStudents();
    }
}
