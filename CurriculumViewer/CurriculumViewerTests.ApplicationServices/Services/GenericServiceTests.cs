using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CurriculumViewerTests.Services
{
	public class GenericServiceTests
	{
		[Fact]
        public void ShouldGetListWithFindAllMethod()
        {
            Mock<IGenericRepository<ExamProgram>> examProgramRepositoryMock = new Mock<IGenericRepository<ExamProgram>>();
            Mock<IActivityLoggerService> activityLoggerMock = new Mock<IActivityLoggerService>();

            IEnumerable<ExamProgram> testData = new List<ExamProgram>() {
                new ExamProgram()
                {
                    Id = 0,
                    EndDate = System.DateTime.Now.AddYears(1),
                    StartDate = System.DateTime.Now
                },
                new ExamProgram()
                {
                    Id = 1,
                    EndDate = System.DateTime.Now.AddYears(2),
                    StartDate = System.DateTime.Now.AddYears(1)
                }
            };

            examProgramRepositoryMock.Setup((e) => e.FindAll(null, 0, 0)).Returns(testData.AsQueryable());

            IGenericService<ExamProgram> examProgramService = new GenericService<ExamProgram>(examProgramRepositoryMock.Object, activityLoggerMock.Object);

            List<ExamProgram> result = examProgramService.FindAll().ToList();

            Assert.Equal(2, result.Count());
            Assert.Equal(0, result[0].Id);
            Assert.Equal(1, result[1].Id);
        }

		[Fact]
		public void ShouldGetOneItemWithFindByIdMethod()
		{
			Mock<IGenericRepository<ExamProgram>> examProgramRepositoryMock = new Mock<IGenericRepository<ExamProgram>>();
            Mock<IActivityLoggerService> activityLoggerMock = new Mock<IActivityLoggerService>();

            examProgramRepositoryMock.Setup((e) => e.FindById("10", null)).Returns(new ExamProgram()
			{
				Id = 10,
				EndDate = System.DateTime.Now.AddYears(1),
				StartDate = System.DateTime.Now,
				Courses = new List<Course>()
			});

			IGenericService<ExamProgram> ExamProgramService = new GenericService<ExamProgram>(examProgramRepositoryMock.Object, activityLoggerMock.Object);

			ExamProgram result = ExamProgramService.FindById("10");

			Assert.NotNull(result);
			Assert.Equal(10, result.Id);
		}

		[Fact]
        public void ShouldUpdateWithReturnCodeZero()
        {
            Mock<IGenericRepository<ExamProgram>> examProgramRepositoryMock = new Mock<IGenericRepository<ExamProgram>>();
            Mock<IActivityLoggerService> activityLoggerMock = new Mock<IActivityLoggerService>();

            examProgramRepositoryMock.Setup((e) => e.Update(new ExamProgram())).Returns(0);

            IGenericService<ExamProgram> examProgramService = new GenericService<ExamProgram>(examProgramRepositoryMock.Object, activityLoggerMock.Object);

            int result = examProgramService.Update(new ExamProgram());

            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldDeleteWithReturnCodeZero()
        {
            Mock<IGenericRepository<ExamProgram>> examProgramRepositoryMock = new Mock<IGenericRepository<ExamProgram>>();
            Mock<IActivityLoggerService> activityLoggerMock = new Mock<IActivityLoggerService>();

            examProgramRepositoryMock.Setup((e) => e.Delete(new ExamProgram())).Returns(0);

            IGenericService<ExamProgram> examProgramService = new GenericService<ExamProgram>(examProgramRepositoryMock.Object, activityLoggerMock.Object);

            int result = examProgramService.Delete(new ExamProgram());

            Assert.Equal(0, result);
        }

        [Fact]
        public void ShouldInsertWithReturnCodeZero()
        {
            Mock<IGenericRepository<ExamProgram>> examProgramRepositoryMock = new Mock<IGenericRepository<ExamProgram>>();
            Mock<IActivityLoggerService> activityLoggerMock = new Mock<IActivityLoggerService>();

            examProgramRepositoryMock.Setup((e) => e.Insert(new ExamProgram())).Returns(0);

            IGenericService<ExamProgram> examProgramService = new GenericService<ExamProgram>(examProgramRepositoryMock.Object, activityLoggerMock.Object);

            int result = examProgramService.Insert(new ExamProgram());

            Assert.Equal(0, result);
        }
    }
}
