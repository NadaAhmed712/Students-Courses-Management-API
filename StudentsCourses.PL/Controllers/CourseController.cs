using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsCourses.BLL.Dto.Course;
using StudentsCourses.BLL.Services.Abstraction;

namespace StudentsCourses.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet("Courses")]
        [Authorize(Roles = "Admin,Student")]
        public IActionResult GetAllCourse()
        {
            //throw new Exception("Test exception handling middleware");
            var response = _courseService.GetCourses();
            if (response.Result.Count == 0)
                return NotFound();

            return Ok(response.Result);
        }

        [HttpGet("Courses/{id}")]
        [Authorize(Roles = "Admin,Student")]

        public IActionResult GetByIdCourse([FromRoute] int id)
        {
            var response = _courseService.GetCourse(id);

            if (response.Result == null)
                return NotFound();

            return Ok(response.Result);
        }

        [HttpPut("Courses/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult UpdateCourse([FromRoute] int id, [FromBody] UpdateCourseDTO course)
        {
            var respose = _courseService.Edit(course);
            if (respose.Result == false)
                return NotFound(); // 404
            return Ok(); // 204
        }


        [HttpDelete("Courses/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteCourse([FromRoute] int id)
        {
            var respose = _courseService.Delete(id);
            if (respose.Result == false)
                return NotFound(); // 404
            return NoContent(); // 204
        }

        [HttpPost("Courses")]

        [Authorize(Roles = "Admin")]
        public IActionResult CreateCourse([FromBody] CreateCourseDTO course)
        {
            var response = _courseService.Add(course);
            if (response.Result == false)
                return BadRequest(); // 400
            return Created(); // 201
        }

        
    }
}
