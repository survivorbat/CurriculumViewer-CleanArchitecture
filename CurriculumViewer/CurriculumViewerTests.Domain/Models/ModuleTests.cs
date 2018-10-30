using CurriculumViewer.Domain.Models;
using System.Collections.Generic;
using Xunit;

namespace CurriculumViewerTests.Domain.Models
{
    public class ModuleTests
    {
        [Fact]
        public void TestIFECIsCalculatedForOneExam()
        {
            // Arange
            Module module = new Module();
            IList<Exam> moduleExam = new List<Exam>
                {
                    new Exam() { EC = 10 }
                };
            module.Exams = moduleExam;

            // Act
            int ec = module.EC;

            // Assert
            Assert.Equal(10, ec);
        }

        [Fact]
        public void TestIFECIsCalculatedForMoreExams()
        {
            // Arange
            Module module = new Module();
            IList<Exam> moduleExam = new List<Exam>
                {
                    new Exam() { EC = 10 },
                    new Exam() { EC = 5 },
                    new Exam() { EC = 8 },
                };
            module.Exams = moduleExam;

            // Act
            int ec = module.EC;

            // Assert
            Assert.Equal(23, ec);
        }
    }
}
