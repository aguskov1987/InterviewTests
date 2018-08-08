using System.Linq;
using GraduationTracker.Models;

namespace GraduationTracker
{
    public static class Repository
    {
        public static Student GetStudent(int id)
        {
            var students = GetStudents();
            return students.FirstOrDefault(s => s.Id == id);
        }

        public static Diploma GetDiploma(int id)
        {
            var diplomas = GetDiplomas();
            return diplomas.FirstOrDefault(d => d.Id == id);
        }

        public static Requirement GetRequirement(int id)
        {
            var requirements = GetRequirements();
            return requirements.FirstOrDefault(r => r.Id == id);
        }


        private static Diploma[] GetDiplomas()
        {
            return new[]
            {
                new Diploma
                {
                    Id = 1,
                    Requirements = GetRequirements()
                }
            };
        }

        private static Course[] GetCources()
        {
            return new[]
            {
                new Course {Id = 1, Name = "Basic Math", Credits = 1},
                new Course {Id = 2, Name = "Calculus", Credits = 1},
                new Course {Id = 3, Name = "Science", Credits = 1},
                new Course {Id = 4, Name = "Literature", Credits = 1},
                new Course {Id = 5, Name = "Physical Education", Credits = 1}
            };
        }

        private static Requirement[] GetRequirements()
        {
            Course[] cources = GetCources();
            return new[]
                {
                    new Requirement{Id = 100, Name = "Math", MinimumMark=50, RequiredCourses = new[] {cources[0], cources[1]}, RequiredCredits = 2 },
                    new Requirement{Id = 102, Name = "Science", MinimumMark=50, RequiredCourses = new[] {cources[1]}, RequiredCredits = 1 },
                    new Requirement{Id = 103, Name = "Literature", MinimumMark=50, RequiredCourses = new[] {cources[2]}, RequiredCredits = 1 },
                    new Requirement{Id = 104, Name = "Physical Education", MinimumMark=50, RequiredCourses = new[] {cources[3]}, RequiredCredits = 1 }
                };
        }

        private static Student[] GetStudents()
        {
            Course[] cources = GetCources();
            return new[]
            {
               new Student // passes everything with flying colors
               {
                   Id = 1,
                   Courses = new[]
                   {
                        new CompletedCource(cources[0], 95),
                        new CompletedCource(cources[1], 95),
                        new CompletedCource(cources[2], 95),
                        new CompletedCource(cources[3], 95),
                        new CompletedCource(cources[4], 95)
                   }
               },
               new Student // fails calculus
               {
                   Id = 2,
                   Courses = new[]
                   {
                       new CompletedCource(cources[0], 80),
                       new CompletedCource(cources[1], 40),
                       new CompletedCource(cources[2], 80),
                       new CompletedCource(cources[3], 80),
                       new CompletedCource(cources[4], 80)
                   }
               },
            new Student // barely passes
            {
                Id = 3,
                Courses = new[]
                {
                    new CompletedCource(cources[0], 50),
                    new CompletedCource(cources[1], 50),
                    new CompletedCource(cources[2], 50),
                    new CompletedCource(cources[3], 50),
                    new CompletedCource(cources[4], 50)
                }
            },
            new Student // shame
            {
                Id = 4,
                Courses = new[]
                {
                    new CompletedCource(cources[0], 40),
                    new CompletedCource(cources[1], 40),
                    new CompletedCource(cources[2], 40),
                    new CompletedCource(cources[3], 40),
                    new CompletedCource(cources[4], 40)
                }
            }

            };
        }
    }
}
