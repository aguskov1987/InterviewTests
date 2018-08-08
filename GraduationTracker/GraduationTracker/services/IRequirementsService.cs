using GraduationTracker.Models;

namespace GraduationTracker.Services
{
    public interface IRequirementsService
    {
        bool CreditsFulfilled(Requirement requirement, Student student);
        int GetStudentAverage(Student student);
    }
}
