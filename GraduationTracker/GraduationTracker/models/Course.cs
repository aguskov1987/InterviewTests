namespace GraduationTracker.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }

    public class CompletedCource
    {
        public CompletedCource(Course cource, int mark)
        {
            Cource = cource;
            Mark = mark;
        }

        public Course Cource { get; set; }
        public int Mark { get; set; }
    }
}
