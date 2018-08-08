namespace GraduationTracker.Models
{
    public class Student
    {
        public int Id { get; set; }
        public CompletedCource[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;
    }
}
