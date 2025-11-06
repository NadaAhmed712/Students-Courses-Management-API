using StudentsCourses.BLL.Dto.Course;
using StudentsCourses.BLL.ResponseResult;

namespace StudentsCourses.BLL.Services.Abstraction
{
    public interface ICourseService
    {
        Response<bool> Add(CreateCourseDTO course);
        Response<bool> Edit(UpdateCourseDTO course);
        Response<bool> Delete(int id);
        Response<GetCourseDTO> GetCourse(int id);
        Response<List<GetCourseDTO>> GetCourses();
    }
}
