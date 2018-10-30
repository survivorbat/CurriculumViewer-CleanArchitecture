using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class ExamProgramTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();

			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				StartDate = DateTime.Now.Date
			};

			examProgramServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<ExamProgram>()
			{
				examProgram,
				new ExamProgram() { Id = 101 },
				new ExamProgram() { Id = 102 },
			});

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object);
			List<ExamProgram> model = (controller.Index() as ViewResult)?.ViewData.Model as List<ExamProgram>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal(DateTime.Now.Date, model[0].StartDate);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();

			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				StartDate = DateTime.Now.Date
			};

			examProgramServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(examProgram);

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object);
			ExamProgram model = (controller.Details(examProgram.Id) as ViewResult)?.ViewData.Model as ExamProgram;

			Assert.Equal(100, model.Id);
			Assert.Equal(DateTime.Now.Date, model.StartDate);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();
			
			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				StartDate = DateTime.Now.Date,
				EndDate = DateTime.Now.Date.AddDays(30)
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examProgramServiceMock.Setup(m => m.Insert(It.IsAny<ExamProgram>())).Returns((ExamProgram model) =>
			{
				if (model.StartDate != null && model.EndDate != null && model.Courses != null && !string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});
			
			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(examProgram) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();
			
			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				StartDate = DateTime.Now.Date,
				EndDate = DateTime.Now.Date.AddDays(30)
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examProgramServiceMock.Setup(m => m.Update(It.IsAny<ExamProgram>())).Returns((ExamProgram model) =>
			{
				if (model.StartDate != null && model.EndDate != null && model.Courses != null && !string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(examProgram) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();		

			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				StartDate = DateTime.Now.Date,
				EndDate = DateTime.Now.Date.AddDays(30)
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examProgramServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(examProgram);

			examProgramServiceMock.Setup(m => m.Delete(It.IsAny<ExamProgram>())).Returns((ExamProgram model) =>
			{
				return 1;
			});

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(examProgram.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();		

			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				Courses = null
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examProgramServiceMock.Setup(m => m.Insert(It.IsAny<ExamProgram>())).Returns((ExamProgram model) =>
			{
				if (model.StartDate != null && model.EndDate != null && model.Courses != null && !string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(examProgram) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();

			ExamProgram examProgram = new ExamProgram()
			{
				Id = 100,
				Courses = null
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examProgramServiceMock.Setup(m => m.Update(It.IsAny<ExamProgram>())).Returns((ExamProgram model) =>
			{
				if (model.StartDate != null && model.EndDate != null && model.Courses != null && !string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamProgramController controller = new ExamProgramController(examProgramServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(examProgram) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}
