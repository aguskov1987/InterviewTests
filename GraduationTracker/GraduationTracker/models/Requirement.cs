namespace GraduationTracker.Models
{
    public class Requirement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinimumMark { get; set; }
        public int RequiredCredits { get; set; }
        public Course[] RequiredCourses { get; set; }
    }
}
