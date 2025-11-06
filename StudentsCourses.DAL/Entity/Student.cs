
using Azure;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;


namespace StudentsCourses.DAL.Entity
{
    public class Student
    {
         public int Id { get; set; }
         public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
        [ForeignKey("Department")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        protected Student() { }
        public Student(string name, string email, DateTime enrollmentDate, int courseId)
        {
            FullName = name;
            Email = email;
            EnrollmentDate = enrollmentDate;
            CourseId = courseId;
        }
        public bool Update(string name, string email, DateTime enrollmentDate, int courseId)
        {
            FullName = name;
            Email = email;
            EnrollmentDate = enrollmentDate;
            CourseId = courseId;
            return true;
        }
    }
}
