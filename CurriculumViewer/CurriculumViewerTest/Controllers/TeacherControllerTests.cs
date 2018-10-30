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
	public class TeacherControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius"
			};

			teacherServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Teacher>()
			{
				teacher,
				new Teacher() { Id = 101 },
				new Teacher() { Id = 102 },
			});

			TeacherController controller = new TeacherController(teacherServiceMock.Object);

			List<Teacher> model = (controller.Index() as ViewResult)?.ViewData.Model as List<Teacher>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal("Robin Schellius", model[0].FullName);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius"
			};

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(teacher);

			TeacherController controller = new TeacherController(teacherServiceMock.Object);
			Teacher model = (controller.Details(teacher.Id) as ViewResult)?.ViewData.Model as Teacher;

			Assert.Equal(100, model.Id);
			Assert.Equal("Robin Schellius", model.FullName);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.Insert(It.IsAny<Teacher>())).Returns((Teacher model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.FullName))
				{
					return 1;
				}

				return 0;
			});

			TeacherController controller = new TeacherController(teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(teacher) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.Update(It.IsAny<Teacher>())).Returns((Teacher model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.FullName))
				{
					return 1;
				}

				return 0;
			});

			TeacherController controller = new TeacherController(teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(teacher) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius"
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(teacher);

			teacherServiceMock.Setup(m => m.Delete(It.IsAny<Teacher>())).Returns((Teacher model) =>
			{
				return 1;
			});

			loggerMock.Setup(m => m.Delete(It.IsAny<string>()));

			TeacherController controller = new TeacherController(teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(teacher.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius",
				ResponsibleForCourses = null
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.Insert(It.IsAny<Teacher>())).Returns((Teacher model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.FullName) && model.ResponsibleForCourses != null)
				{
					return 1;
				}

				return 0;
			});

			TeacherController controller = new TeacherController(teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(teacher) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			Teacher teacher = new Teacher()
			{
				Id = 100,
				FirstName = "Robin",
				LastName = "Schellius",
				ResponsibleForCourses = null
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.Update(It.IsAny<Teacher>())).Returns((Teacher model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.FullName) && model.ResponsibleForCourses != null)
				{
					return 1;
				}

				return 0;
			});

			TeacherController controller = new TeacherController(teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(teacher) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}
