using AutoMapper;
using StudentsCourses.BLL.Dto.Course;
using StudentsCourses.BLL.ResponseResult;
using StudentsCourses.BLL.Services.Abstraction;
using StudentsCourses.DAL.Entity;
using StudentsCourses.DAL.Repo.Abstraction;

namespace StudentsCourses.BLL.Services.Impelementation
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepo _courseRepo;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepo courseRepo, IMapper mapper)
        {
            _courseRepo = courseRepo;
            _mapper = mapper;
        }
        public Response<bool> Add(CreateCourseDTO course)
        {
            try
            {

                var newCourse = new Course(course.Name,course.Description,course.Level);
                var result = _courseRepo.Add(newCourse);
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
            try{
                var result = _courseRepo.GetCourseById(id);
                if (result == null)

                    return new Response<bool>(false, "There is no Course with this Id", true);
                _courseRepo.Delete(result);

                return new Response<bool>(true, null, false);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);

            }
        }

        public Response<bool> Edit(UpdateCourseDTO course)
        {
            try
            {
                var map = _mapper.Map<Course>(course);

                var flag = _courseRepo.Edit(map);
                if (flag)
                    return new Response<bool>(true, null, false);
                else
                    return new Response<bool>(false, "Failed to update Course.", true);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, ex.Message, true);
            }
        }

        public Response<GetCourseDTO> GetCourse(int id)
        {
            try
            {
                var result = _courseRepo.GetCourseById(id);
                if (result == null)

                    return new Response<GetCourseDTO>(null, "There is no Course with this Id", true);
                var resultVM = _mapper.Map<GetCourseDTO>(result);

                return new Response<GetCourseDTO>(resultVM, null, false);
            }
            catch (Exception ex)
            {
                return new Response<GetCourseDTO>(null, ex.Message, true);

            }
        }

        public Response<List<GetCourseDTO>> GetCourses()
        {
            try
            {
                var result = _courseRepo.GetAll();
                var resultDTO = _mapper.Map<List<GetCourseDTO>>(result);
                return new Response<List<GetCourseDTO>>(resultDTO, null, false);
            }
            catch (Exception ex)
            {
                return new Response<List<GetCourseDTO>>(null, ex.Message, true);

            }
        }
    }
}
