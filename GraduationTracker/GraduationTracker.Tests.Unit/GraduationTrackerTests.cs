using Microsoft.VisualStudio.TestTools.UnitTesting;
using GraduationTracker.Models;
using GraduationTracker.Services;

namespace GraduationTracker.Tests.Unit
{
    // This is not how I would normally do it. I would use a mocking library to dynamically
    // alter the behavior of the mock for each test. Here I am only going to use it for one test
    internal class ServiceMock : IRequirementsService
    {
        public bool CreditsFulfilled(Requirement requirement, Student student)
        {
            return true;
        }

        public int GetStudentAverage(Student student)
        {
            return 95;
        }
    }

    // After some refactoring, the original test did not make much sense anymore;
    // besides, it my opinion, it was testing too much. So I broke it down into several smaller ones
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void ShouldHaveEnoughCredits()
        {
            // Arrange
            RequirementsService service = new RequirementsService();
            Diploma diploma = Repository.GetDiploma(1);
            Student student = Repository.GetStudent(1);

            // Act
            bool result = service.CreditsFulfilled(diploma.Requirements[0], student);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ShouldNotHaveEnoughCredits()
        {
            // Arrange
            RequirementsService service = new RequirementsService();
            Diploma diploma = Repository.GetDiploma(1);
            Student student = Repository.GetStudent(2);

            // Act
            bool result = service.CreditsFulfilled(diploma.Requirements[0], student);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ShouldGetAnAverageOf95()
        {
            // Arrange
            RequirementsService service = new RequirementsService();
            Student student = Repository.GetStudent(1);

            // Act
            int result = service.GetStudentAverage(student);

            // Assert
            Assert.AreEqual(95, result);
        }

        [TestMethod]
        public void ShouldGetAnAverageOf72()
        {
            // Arrange
            RequirementsService service = new RequirementsService();
            Student student = Repository.GetStudent(2);

            // Act
            int result = service.GetStudentAverage(student);

            // Assert
            Assert.AreEqual(72, result);
        }

        [TestMethod]
        public void ShouldGraduateWithMagnaCumLaude()
        {
            // Arrange
            
            GraduationTracker tracker = new GraduationTracker(new ServiceMock());
            Diploma diploma = Repository.GetDiploma(1);
            Student student = Repository.GetStudent(1);

            // Act
            Standing result = tracker.HasGraduated(diploma, student);

            //Assert
            Assert.AreEqual(Standing.MagnaCumLaude, result);
        }
    }
}
