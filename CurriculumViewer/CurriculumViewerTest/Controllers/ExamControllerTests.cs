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
	public class ExamControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true
			};

			examServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Exam>()
			{
				exam,
				new Exam() { Id = 101 },
				new Exam() { Id = 102 },
			});

			ExamController controller = new ExamController(examServiceMock.Object);
			List<Exam> model = (controller.Index() as ViewResult)?.ViewData.Model as List<Exam>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal(DateTime.Now.Date, model[0].AttemptOne);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<Exam>> examMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true
			};

			examMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(exam);

			ExamController controller = new ExamController(examMock.Object);
			Exam model = (controller.Details(exam.Id) as ViewResult)?.ViewData.Model as Exam;

			Assert.Equal(100, model.Id);
			Assert.Equal(DateTime.Now.Date, model.AttemptOne);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				Language = "NL",
				ResponsibleTeacher = new Teacher()
				{
					FirstName = "Robin",
					LastName = "Schellius"
				},
				Module = new Module()
				{
					Name = "Client-side web frameworks",
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examServiceMock.Setup(m => m.Insert(It.IsAny<Exam>())).Returns((Exam model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Language) && !string.IsNullOrWhiteSpace(model.ResponsibleTeacher?.FullName) && !string.IsNullOrWhiteSpace(model.ExamType) && !string.IsNullOrWhiteSpace(model.Module?.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamController controller = new ExamController(examServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(exam) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				Language = "NL",
				ResponsibleTeacher = new Teacher()
				{
					FirstName = "Robin",
					LastName = "Schellius"
				},
				Module = new Module()
				{
					Name = "Client-side web frameworks",
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examServiceMock.Setup(m => m.Update(It.IsAny<Exam>())).Returns((Exam model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Language) && !string.IsNullOrWhiteSpace(model.ResponsibleTeacher?.FullName) && !string.IsNullOrWhiteSpace(model.ExamType) && !string.IsNullOrWhiteSpace(model.Module?.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamController controller = new ExamController(examServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(exam) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				Language = "NL",
				ResponsibleTeacher = new Teacher()
				{
					FirstName = "Robin",
					LastName = "Schellius"
				},
				Module = new Module()
				{
					Name = "Client-side web frameworks",
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(exam);

			examServiceMock.Setup(m => m.Delete(It.IsAny<Exam>())).Returns((Exam model) =>
			{
				return 1;
			});

			ExamController controller = new ExamController(examServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(exam.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				Language = "NL",
				ResponsibleTeacher = null,
				Module = new Module()
				{
					Name = "Client-side web frameworks",
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examServiceMock.Setup(m => m.Insert(It.IsAny<Exam>())).Returns((Exam model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Language) && !string.IsNullOrWhiteSpace(model.ResponsibleTeacher?.FullName) && !string.IsNullOrWhiteSpace(model.ExamType) && !string.IsNullOrWhiteSpace(model.Module?.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamController controller = new ExamController(examServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(exam) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();

			Exam exam = new Exam()
			{
				Id = 100,
				AttemptOne = DateTime.Now.Date,
				AttemptTwo = DateTime.Now.Date.AddDays(14),
				EC = 3,
				Duration = TimeSpan.FromMinutes(30),
				Compensatable = true,
				ExamType = "Vh:essaytoets + vh+att:gedragsassessment + vh:portfolio-assessment + vh:vaardigheidstoets(R)",
				Language = "NL",
				ResponsibleTeacher = null,
				Module = new Module()
				{
					Name = "Client-side web frameworks",
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examServiceMock.Setup(m => m.Update(It.IsAny<Exam>())).Returns((Exam model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Language) && !string.IsNullOrWhiteSpace(model.ResponsibleTeacher?.FullName) && !string.IsNullOrWhiteSpace(model.ExamType) && !string.IsNullOrWhiteSpace(model.Module?.Name))
				{
					return 1;
				}

				return 0;
			});

			ExamController controller = new ExamController(examServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(exam) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}