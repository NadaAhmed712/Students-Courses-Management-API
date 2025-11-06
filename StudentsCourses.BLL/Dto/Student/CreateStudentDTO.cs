using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCourses.BLL.Dto.Student
{
    public class CreateStudentDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CourseId { get; set; }
    }
}
