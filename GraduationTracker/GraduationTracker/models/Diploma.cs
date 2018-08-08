namespace GraduationTracker.Models
{
    // I removed the credits parts of the Diploma as it seems like the required credits
    // is just the sum of the credits of the requirements
    public class Diploma
    {
        public int Id { get; set; }
        public Requirement[] Requirements { get; set; }
    }
}
