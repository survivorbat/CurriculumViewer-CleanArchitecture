using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace CurriculumViewerTests.ApplicationServices.Services
{
	public class ObjectFinderTests
	{
		[Fact]
        public void ShouldReturnTrueIfIdsAreValid()
        {
            Mock<IGenericService<Module>> mockService = new Mock<IGenericService<Module>>();

            mockService.Setup((e) => e.FindBy(It.IsAny<Expression<Func<Module, bool>>[]>(), null, 0, 0)).Returns(new List<Module>()
            {
                new Module()
                {
                    Name = "Testmodule",
                    Id = 1,
                },
                new Module()
                {
                    Name = "Second testmodule",
                    Id = 2
                }
            });

            IObjectFinderService<Module> objectFinder = new ObjectFinderService<Module>(mockService.Object);

            bool result = objectFinder.AreIdsValid(new int[] { 1, 2 });

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalseIfIdsAreNotValid()
        {
            Mock<IGenericService<Module>> mockService = new Mock<IGenericService<Module>>();

            mockService.Setup((e) => e.FindBy(It.IsAny<Expression<Func<Module, bool>>[]>(), null, 0, 0)).Returns(new List<Module>()
            {
                new Module()
                {
                    Name = "Testmodule",
                    Id = 1,
                },
                new Module()
                {
                    Name = "Second testmodule",
                    Id = 2
                },
            });

            IObjectFinderService<Module> objectFinder = new ObjectFinderService<Module>(mockService.Object);

            Assert.False(objectFinder.AreIdsValid(new int[] { 1, 2, 3 }));
        }

        [Fact]
        public void ShouldReturnCorrectObjects()
        {
            Mock<IGenericService<Module>> mockService = new Mock<IGenericService<Module>>();

            mockService.Setup((e) => e.FindBy(It.IsAny<Expression<Func<Module, bool>>[]>(), null, 0, 0)).Returns(new List<Module>()
            {
                new Module()
                {
                    Name = "Testmodule",
                    Id = 1,
                },
                new Module()
                {
                    Name = "Second testmodule",
                    Id = 2
                },
            });

            IObjectFinderService<Module> objectFinder = new ObjectFinderService<Module>(mockService.Object);

            Assert.Equal(2, objectFinder.GetObjects(new int[] { 1, 2 } ).Count());

            List<int> resultIds = objectFinder.GetObjects(new int[] { 1, 2 }).Select(e => e.Id).ToList();

            Assert.Contains(2, resultIds);
            Assert.Contains(1, resultIds);
        }

        [Fact]
        public void ShouldReturnIncorrectObjectsWithoutValidIdsCheck()
        {
            Mock<IGenericService<Module>> mockService = new Mock<IGenericService<Module>>();

            mockService.Setup((e) => e.FindBy(It.IsAny<Expression<Func<Module, bool>>[]>(), null, 0, 0)).Returns(new List<Module>()
            {
                new Module()
                {
                    Name = "Testmodule",
                    Id = 1,
                },
                new Module()
                {
                    Name = "Second testmodule",
                    Id = 2
                },
                new Module()
                {
                    Name = "Errormodule",
                    Id = 3
                },
            });

            IObjectFinderService<Module> objectFinder = new ObjectFinderService<Module>(mockService.Object);

            Assert.Equal(3, objectFinder.GetObjects(new int[] { 1, 2 }).Count());
        }
    }
}
