using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CurriculumViewerTests.ApplicationServices.Services
{
	public class ManyToManyMapperServiceTests
	{
		[Fact]
        public void ShouldReturnCorrectlyMappedEntities()
        {
            Course course = new Course()
            {
                Name = "Cursus 1",
                Description = "Course description",
                Id = 1001,
                Mentor = new Teacher()
				{
					FirstName = "Robin Schellius",
					LastName = "Schellius"
				}
            };

            List<Module> modules = new List<Module>
            {
                new Module()
                {
                    Name = "Module 1",
                    Description = "Module 1",
                    OsirisCode = "ËIIN-MOD1",
                    Id = 100
                },
                new Module()
                {
                    Name = "Module 2",
                    Description = "Module 2",
                    OsirisCode = "ËIIN-MOD2",
                    Id = 101
                }
            };

            IManyToManyMapperService<Course, CourseModule, Module> mapper = new ManyToManyMapperService<Course, CourseModule, Module>();

            course.Modules = mapper.GetMappedEntities(course, modules);

            Assert.Equal(2, course.Modules.Count);

            List<int> resultModules = course.Modules.Select((e) => e.ModuleId).ToList();

            Assert.Contains(101, resultModules);
            Assert.Contains(100, resultModules);
        }
    }
}
