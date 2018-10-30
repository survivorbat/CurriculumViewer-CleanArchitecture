using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.Domain.Models;
using Moq;
using Xunit;

namespace CurriculumViewerTests.ApplicationServices.Services
{
    public class ActivityLoggerServiceTests
    {
        [Fact]
        public void ShouldCallRightCreateMethods()
        {
            Mock<IGenericRepository<LogItem>> mockRepo = new Mock<IGenericRepository<LogItem>>();

            LogItem controlItem = null;

            mockRepo.Setup(e => e.Insert(It.IsNotNull<LogItem>())).Callback<LogItem>(e => { controlItem = e; });

            IActivityLoggerService activityLogger = new ActivityDatabaseLoggerService(mockRepo.Object);

            activityLogger.Create("Test creating this item");

            Assert.Equal("Test creating this item", controlItem.Message);
            Assert.Equal(LogType.Create, controlItem.LogType);
        }

        [Fact]
        public void ShouldCallRightUpdateMethods()
        {
            Mock<IGenericRepository<LogItem>> mockRepo = new Mock<IGenericRepository<LogItem>>();

            LogItem controlItem = null;

            mockRepo.Setup(e => e.Insert(It.IsNotNull<LogItem>())).Callback<LogItem>(e => { controlItem = e; });

            IActivityLoggerService activityLogger = new ActivityDatabaseLoggerService(mockRepo.Object);

            activityLogger.Update("Test updating this item");

            Assert.Equal("Test updating this item", controlItem.Message);
            Assert.Equal(LogType.Update, controlItem.LogType);
        }

        [Fact]
        public void ShouldCallRightDeleteMethods()
        {
            Mock<IGenericRepository<LogItem>> mockRepo = new Mock<IGenericRepository<LogItem>>();

            LogItem controlItem = null;

            mockRepo.Setup(e => e.Insert(It.IsNotNull<LogItem>())).Callback<LogItem>(e => { controlItem = e; });

            IActivityLoggerService activityLogger = new ActivityDatabaseLoggerService(mockRepo.Object);

            activityLogger.Delete("Test deleting this item");

            Assert.Equal("Test deleting this item", controlItem.Message);
            Assert.Equal(LogType.Delete, controlItem.LogType);
        }
    }
}
