using StudentsCourses.DAL.Enum;

namespace StudentsCourses.DAL.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public List<Student> Students { get; set; }
        protected Course() { }
        public Course(string name, string description, CourseLevel level)
        {
            Name=name;
            Description=description;
            Level=level;
        }
        public bool Update(string name, string description, CourseLevel level)
        {
            Name = name;
            Description = description;
            Level = level;
            return true;
        }
    }
}
