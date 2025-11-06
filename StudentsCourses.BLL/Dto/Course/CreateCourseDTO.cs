using StudentsCourses.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.BLL.Dto.Course
{
    public class CreateCourseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
    }
}
