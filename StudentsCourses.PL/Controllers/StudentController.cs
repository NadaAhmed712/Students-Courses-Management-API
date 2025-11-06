using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentsCourses.BLL.Dto.Student;
using StudentsCourses.BLL.Services.Abstraction;

namespace StudentsCourses.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("Students")]
        [Authorize(Roles = "Admin,Student")]

        public IActionResult GetAllStudent()
        {
            var response = _studentService.GetStudents();
            if (response.Result.Count==0)
                return NotFound(); 

            return Ok(response.Result); 
        }

        [HttpGet("Students/{id}")]
        [Authorize(Roles = "Admin,Student")]

        public IActionResult GetByIdStudent([FromRoute] int id)
        {
            var response = _studentService.GetStudent(id);

            if (response.Result == null)
                return NotFound(); 

            return Ok(response.Result);
        }


        [HttpDelete("Students/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteStudent([FromRoute] int id)
        {
            var respose= _studentService.Delete(id);
            if(respose.Result== false)
                return NotFound(); // 404
            return NoContent(); // 204
        }

        [HttpPost("Students")]
        [Authorize(Roles = "Admin")]

        public IActionResult CreateStudent([FromBody] CreateStudentDTO student)
        {
            var response=_studentService.Add(student);
            if(response.Result== false)
                return BadRequest(); // 400
            return Created(); // 201
        }

        [HttpPut("Students/{id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult UpdateStudent([FromRoute] int id, [FromBody] UpdateStudentDTO student)
        {
            var respose = _studentService.Edit(student);
            if (respose.Result == false)
                return NotFound(); // 404
            return Ok(); // 204
        }
        
    }
}
