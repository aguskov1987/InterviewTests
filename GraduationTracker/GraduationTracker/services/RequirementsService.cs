using System.Linq;
using GraduationTracker.Models;

namespace GraduationTracker.Services
{
    public class RequirementsService : IRequirementsService
    {
        public bool CreditsFulfilled(Requirement requirement, Student student)
        {
            int earnedCredited = 0;
            foreach (Course requiredCourse in requirement.RequiredCourses)
            {
                var match = student.Courses.FirstOrDefault(c => c.Cource.Id == requiredCourse.Id);
                if (match != null && match.Mark >= requirement.MinimumMark)
                {
                    earnedCredited += requiredCourse.Credits;
                }
            }

            return earnedCredited >= requirement.RequiredCredits;
        }

        public int GetStudentAverage(Student student)
        {
            int total = student.Courses.Sum(c => c.Mark);
            return total / student.Courses.Length;
        }
    }
}
