using CurriculumViewer.Domain.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CurriculumViewerTests.Domain.Models
{
    public class CourseTests
    {
        [Fact]
        public void TestIFECIsCalculatedForOneModule()
        {
            // Arange
            Course course = new Course();
            var module = new Mock<Module>();
            module.Setup(x => x.EC).Returns(10);

            IList<CourseModule> courseModules = new List<CourseModule>
                {
                    new CourseModule { Course = course, Module = module.Object }
                };

            course.Modules = courseModules;

            // Act
            int ec = course.EC;

            // Assert
            Assert.Equal(10, ec);
        }

        [Fact]
        public void TestIFECIsCalculatedForManyModules()
        {
            // Arange
            Course course = new Course();
            var module = new Mock<Module>();
            module.Setup(x => x.EC).Returns(10);
            var module2 = new Mock<Module>();
            module2.Setup(x => x.EC).Returns(2);
            var module3 = new Mock<Module>();
            module3.Setup(x => x.EC).Returns(6);

            IList<CourseModule> courseModules = new List<CourseModule>
                {
                    new CourseModule { Course = course, Module = module.Object },
                    new CourseModule { Course = course, Module = module2.Object },
                    new CourseModule { Course = course, Module = module3.Object }
                };

            course.Modules = courseModules;

            // Act
            int ec = course.EC;

            // Assert
            Assert.Equal(18, ec);
        }
    }
}
