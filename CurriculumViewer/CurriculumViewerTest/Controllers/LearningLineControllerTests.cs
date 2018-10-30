using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class LearningLineControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();

			LearningLine learningLine = new LearningLine()
			{
				Id = 100,
				Name = "Computernetwerken"
			};

			learningLineServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<LearningLine>()
			{
				learningLine,
				new LearningLine() { Id = 101 },
				new LearningLine() { Id = 102 },
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, null, null, null);
			List<LearningLine> model = (controller.Index() as ViewResult)?.ViewData.Model as List<LearningLine>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal("Computernetwerken", model[0].Name);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();

			LearningLine learningLine = new LearningLine()
			{
				Id = 100,
				Name = "Computernetwerken"
			};

			learningLineServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(learningLine);

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, null, null, null);
			LearningLine model = (controller.Details(learningLine.Id) as ViewResult)?.ViewData.Model as LearningLine;

			Assert.Equal(100, model.Id);
			Assert.Equal("Computernetwerken", model.Name);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>> mapperServiceMock = new Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>>();

			LearningLineCreateUpdateViewModel learningLine = new LearningLineCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Computernetwerken"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<LearningLine>(), It.IsAny<ICollection<Goal>>())).Returns<LearningLine, ICollection<Goal>>((model, learningLineGoals) =>
			{
				return new List<LearningLineGoal>();
			});

			learningLineServiceMock.Setup(m => m.Insert(It.IsAny<LearningLine>())).Returns((LearningLine model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, mapperServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(learningLine) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>> mapperServiceMock = new Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>>();

			LearningLineCreateUpdateViewModel learningLine = new LearningLineCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Computernetwerken"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<LearningLine>(), It.IsAny<ICollection<Goal>>())).Returns<LearningLine, ICollection<Goal>>((model, learningLineGoals) =>
			{
				return new List<LearningLineGoal>();
			});

			learningLineServiceMock.Setup(m => m.Update(It.IsAny<LearningLine>())).Returns((LearningLine model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, mapperServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(learningLine) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>> mapperServiceMock = new Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>>();

			LearningLine learningLine = new LearningLine()
			{
				Id = 100,
				Name = "Computernetwerken"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			learningLineServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(learningLine);

			learningLineServiceMock.Setup(m => m.Delete(It.IsAny<LearningLine>())).Returns((LearningLine model) =>
			{
				return 1;
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, mapperServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(learningLine.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>> mapperServiceMock = new Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>>();

			LearningLineCreateUpdateViewModel learningLine = new LearningLineCreateUpdateViewModel()
			{
				Id = 100,
				Name = null	
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<LearningLine>(), It.IsAny<ICollection<Goal>>())).Returns<LearningLine, ICollection<Goal>>((model, learningLineGoals) =>
			{
				return new List<LearningLineGoal>();
			});

			learningLineServiceMock.Setup(m => m.Insert(It.IsAny<LearningLine>())).Returns((LearningLine model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, mapperServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(learningLine) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<LearningLine>> learningLineServiceMock = new Mock<IGenericService<LearningLine>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>> mapperServiceMock = new Mock<IManyToManyMapperService<LearningLine, LearningLineGoal, Goal>>();

			LearningLineCreateUpdateViewModel learningLine = new LearningLineCreateUpdateViewModel()
			{
				Id = 100,
				Name = null
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<LearningLine>(), It.IsAny<ICollection<Goal>>())).Returns<LearningLine, ICollection<Goal>>((model, learningLineGoals) =>
			{
				return new List<LearningLineGoal>();
			});

			learningLineServiceMock.Setup(m => m.Update(It.IsAny<LearningLine>())).Returns((LearningLine model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			LearningLineController controller = new LearningLineController(learningLineServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, mapperServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(learningLine) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}
