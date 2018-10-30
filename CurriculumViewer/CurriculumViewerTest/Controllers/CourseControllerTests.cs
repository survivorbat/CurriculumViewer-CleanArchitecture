using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class CourseControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();

			Course course = new Course()
			{
				Id = 100,
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			courseServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Course>()
			{
				course,
				new Course() { Id = 101 },
				new Course() { Id = 102 },
			});

			CourseController controller = new CourseController(courseServiceMock.Object, null, null, null, null, null);
			List<Course> model = (controller.Index() as ViewResult)?.ViewData.Model as List<Course>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal("Periode 2.3 Data Science", model[0].Name);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();

			Course course = new Course()
			{
				Id = 100,
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			courseServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(course);

			CourseController controller = new CourseController(courseServiceMock.Object, null, null, null, null, null);
			Course model = (controller.Details(course.Id) as ViewResult)?.ViewData.Model as Course;

			Assert.Equal(100, model.Id);
			Assert.Equal("Periode 2.3 Data Science", model.Name);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();
			Mock<IObjectFinderService<Module>> moduleFinderMock = new Mock<IObjectFinderService<Module>>();
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IManyToManyMapperService<Course, CourseModule, Module>> mapperServiceMock = new Mock<IManyToManyMapperService<Course, CourseModule, Module>>();
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();

			CourseCreateUpdateViewModel course = new CourseCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(new Teacher());

			moduleFinderMock.Setup(m => m.AreIdsValid(It.IsAny<int[]>())).Returns(true);

			moduleFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Module>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<Course>(), It.IsAny<ICollection<Module>>())).Returns<Course, ICollection<Module>>((model, modules) =>
			{
				return new List<CourseModule>();
			});

			courseServiceMock.Setup(m => m.Insert(It.IsAny<Course>())).Returns((Course model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			loggerMock.Setup(m => m.Create(It.IsAny<string>()));

			CourseController controller = new CourseController(courseServiceMock.Object, moduleServiceMock.Object, moduleFinderMock.Object, mapperServiceMock.Object, examProgramServiceMock.Object, teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(course) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();
			Mock<IObjectFinderService<Module>> moduleFinderMock = new Mock<IObjectFinderService<Module>>();
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IManyToManyMapperService<Course, CourseModule, Module>> mapperServiceMock = new Mock<IManyToManyMapperService<Course, CourseModule, Module>>();
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			CourseCreateUpdateViewModel course = new CourseCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(new Teacher());

			moduleFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			moduleFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Module>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<Course>(), It.IsAny<ICollection<Module>>())).Returns<Course, ICollection<Module>>((model, modules) =>
			{
				return new List<CourseModule>();
			});

			courseServiceMock.Setup(m => m.Update(It.IsAny<Course>())).Returns((Course model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			loggerMock.Setup(m => m.Update(It.IsAny<string>()));

			CourseController controller = new CourseController(courseServiceMock.Object, moduleServiceMock.Object, moduleFinderMock.Object, mapperServiceMock.Object, examProgramServiceMock.Object, teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(course) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();
			Mock<IObjectFinderService<Module>> moduleFinderMock = new Mock<IObjectFinderService<Module>>();
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IManyToManyMapperService<Course, CourseModule, Module>> mapperServiceMock = new Mock<IManyToManyMapperService<Course, CourseModule, Module>>();
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();

			CourseCreateUpdateViewModel course = new CourseCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Periode 2.3 Data Science",
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			moduleFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			moduleFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Module>();
			});

			courseServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(course);

			courseServiceMock.Setup(m => m.Delete(It.IsAny<Course>())).Returns((Course model) =>
			{
				return 1;
			});

			loggerMock.Setup(m => m.Delete(It.IsAny<string>()));

			CourseController controller = new CourseController(courseServiceMock.Object, moduleServiceMock.Object, moduleFinderMock.Object, mapperServiceMock.Object, examProgramServiceMock.Object, null)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(course.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();
			Mock<IObjectFinderService<Module>> moduleFinderMock = new Mock<IObjectFinderService<Module>>();
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IManyToManyMapperService<Course, CourseModule, Module>> mapperServiceMock = new Mock<IManyToManyMapperService<Course, CourseModule, Module>>();
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			CourseCreateUpdateViewModel course = new CourseCreateUpdateViewModel()
			{
				Id = 100,
				Name = null,
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(new Teacher());

			moduleFinderMock.Setup(m => m.AreIdsValid(It.IsAny<int[]>())).Returns(true);

			moduleFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Module>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<Course>(), It.IsAny<ICollection<Module>>())).Returns<Course, ICollection<Module>>((model, modules) =>
			{
				return new List<CourseModule>();
			});

			courseServiceMock.Setup(m => m.Insert(It.IsAny<Course>())).Returns((Course model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			loggerMock.Setup(m => m.Create(It.IsAny<string>()));

			CourseController controller = new CourseController(courseServiceMock.Object, moduleServiceMock.Object, moduleFinderMock.Object, mapperServiceMock.Object, examProgramServiceMock.Object, teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(course) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<Course>> courseServiceMock = new Mock<IGenericService<Course>>();
			Mock<IActivityLoggerService> loggerMock = new Mock<IActivityLoggerService>();
			Mock<IObjectFinderService<Module>> moduleFinderMock = new Mock<IObjectFinderService<Module>>();
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IManyToManyMapperService<Course, CourseModule, Module>> mapperServiceMock = new Mock<IManyToManyMapperService<Course, CourseModule, Module>>();
			Mock<IGenericService<ExamProgram>> examProgramServiceMock = new Mock<IGenericService<ExamProgram>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();

			CourseCreateUpdateViewModel course = new CourseCreateUpdateViewModel()
			{
				Id = 100,
				Name = null,
				Description = "Alle opdrachten in deze periode zijn gekoppeld aan vakken; dit kunnen individuele of groepsopdrachten zijn; er zijn geen opdrachten die meerdere vakken betreffen. Daarom is een verdere omschrijving hier niet nodig."
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			teacherServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(new Teacher());

			moduleFinderMock.Setup(m => m.AreIdsValid(It.IsAny<string[]>())).Returns(true);

			moduleFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Module>();
			});

			mapperServiceMock.Setup(m => m.GetMappedEntities(It.IsAny<Course>(), It.IsAny<ICollection<Module>>())).Returns<Course, ICollection<Module>>((model, modules) =>
			{
				return new List<CourseModule>();
			});

			courseServiceMock.Setup(m => m.Update(It.IsAny<Course>())).Returns((Course model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name))
				{
					return 1;
				}

				return 0;
			});

			loggerMock.Setup(m => m.Create(It.IsAny<string>()));

			CourseController controller = new CourseController(courseServiceMock.Object, moduleServiceMock.Object, moduleFinderMock.Object, mapperServiceMock.Object, examProgramServiceMock.Object, teacherServiceMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(course) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}
	}
}
