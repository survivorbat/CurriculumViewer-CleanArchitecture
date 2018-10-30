using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class GoalControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			goalServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Goal>()
			{
				goal,
				new Goal() { Id = 101 },
				new Goal() { Id = 102 },
			});

			GoalController controller = new GoalController(goalServiceMock.Object);

			List<Goal> model = (controller.Index() as ViewResult)?.ViewData.Model as List<Goal>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal("Understand", model[0].Bloom);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			goalServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(goal);

			GoalController controller = new GoalController(goalServiceMock.Object);
			Goal model = (controller.Details(goal.Id) as ViewResult)?.ViewData.Model as Goal;

			Assert.Equal(100, model.Id);
			Assert.Equal("Understand", model.Bloom);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<Goal>> goalMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalMock.Setup(m => m.Insert(It.IsAny<Goal>())).Returns((Goal model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Bloom) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});

			GoalController controller = new GoalController(goalMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(goal) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalServiceMock.Setup(m => m.Update(It.IsAny<Goal>())).Returns((Goal model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Bloom) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});

			GoalController controller = new GoalController(goalServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(goal) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = "Understand",
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(goal);

			goalServiceMock.Setup(m => m.Delete(It.IsAny<Goal>())).Returns((Goal model) =>
			{
				return 1;
			});

			GoalController controller = new GoalController(goalServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(goal.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = null,
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalServiceMock.Setup(m => m.Insert(It.IsAny<Goal>())).Returns((Goal model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Bloom) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});

			GoalController controller = new GoalController(goalServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(goal) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();

			Goal goal = new Goal()
			{
				Id = 100,
				Bloom = null,
				Description = @"Je begrijpt de basismechanismen voor access control, zodanig dat je in eigen woorden kunt uitleggen wat de betekenis is in de context van software security. "
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			goalServiceMock.Setup(m => m.Update(It.IsAny<Goal>())).Returns((Goal model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Bloom) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});

			GoalController controller = new GoalController(goalServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(goal) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}
