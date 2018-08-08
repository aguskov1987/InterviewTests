using GraduationTracker.Models;
using GraduationTracker.Services;

// Some comments regarding my approach here:

// First, I removed numerical references between the business objects and used direct object nestring
// after all, this is c# and not a SQL database. 

// Second, as per request, I left the business objects as lean as possible and put the logic in the
// services (or managers if you will). The GraduationTracker was rather scarry, especially with all the nested
// for loops. So, most of the logic has moved into the _requirementsService. The tuple type was a bit ugly;
// do we really need it? I've added an option to the 'Standing' enum which says the requirements have not been fulfilled

// I am adding depenedency injection for the requirements service (in production this should be governed by an
// DI framework and tested using mocks)

// I've renamed a bunch of variables, fixed some typos. Not sure what your take is on 'var' keyword. I usually only use
// it for anonymous types or with constructor initialization

// Would this first run pass a QA test? I doublt it. We usually say in our team - if a feature passes on the first
// run, the tester has done something wrong

// P.S. This is a neat little excersice. I enjoyed it.

namespace GraduationTracker
{
    public class GraduationTracker
    {
        private readonly IRequirementsService _requirementsService;

        public GraduationTracker(IRequirementsService service)
        {
            _requirementsService = service;
        }

        public Standing HasGraduated(Diploma diploma, Student student)
        {     
            foreach (Requirement req in diploma.Requirements)
            {
                bool requirementMet = _requirementsService.CreditsFulfilled(req, student);
                if (!requirementMet)
                {
                    return Standing.CreditsUnfulfilled;
                }
            }

            // Here I am making an assumption. I don't have enough information
            // on how the average is calculated. The original code is rather confusing:
            // it first totals the marks of the cources which ARE on the requirement but
            // then it divides that total by the number of cources the student completed
            // You have to pick one or the other: either compute the average of all cources the
            // student took OR compute the average of the REQUIRED cources. I picked the total
            // of the student completed cources
            int average = _requirementsService.GetStudentAverage(student);

            if (average < 50)
                return Standing.Remedial;
            if (average < 80)
                return Standing.Average;
            if (average < 95)
                return Standing.MagnaCumLaude;

            return Standing.MagnaCumLaude;
        }
    }
}
