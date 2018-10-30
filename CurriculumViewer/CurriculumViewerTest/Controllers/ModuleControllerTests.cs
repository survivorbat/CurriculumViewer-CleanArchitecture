using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class ModuleControllerTests
	{
		[Fact]
		public void ShouldRenderIndexViewCorrectly()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();

			Module module = new Module()
			{
				Id = 100,
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			moduleServiceMock.Setup(m => m.FindAll(It.IsAny<string[]>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Module>()
			{
				module,
				new Module() { Id = 101 },
				new Module() { Id = 102 },
			});

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, null, null, null, null, null, null);
			List<Module> model = (controller.Index() as ViewResult)?.ViewData.Model as List<Module>;

			Assert.Equal(3, model.Count);
			Assert.Equal(100, model[0].Id);
			Assert.Equal(101, model[1].Id);
			Assert.Equal(1, model[0].Goals.Count);
		}

		[Fact]
		public void ShouldRenderDetailViewCorrectly()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();

			Module module = new Module()
			{
				Id = 100,
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			moduleServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(module);

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, null, null, null, null, null, null);
			Module model = (controller.Details(module.Id) as ViewResult)?.ViewData.Model as Module;

			Assert.Equal(100, model.Id);
			Assert.Equal("Server-side web programming project", model.Name);
		}

		[Fact]
		public void ShouldCreateCorrectly()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();
			Mock<IObjectFinderService<Exam>> examFinderMock = new Mock<IObjectFinderService<Exam>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IObjectFinderService<Teacher>> teacherFinderMock = new Mock<IObjectFinderService<Teacher>>();

			ModuleCreateUpdateViewModel module = new ModuleCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Exam>();
			});

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			moduleServiceMock.Setup(m => m.Insert(It.IsAny<Module>())).Returns((ModuleCreateUpdateViewModel model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.OsirisCode) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 1;
			});

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, teacherServiceMock.Object, examFinderMock.Object, examServiceMock.Object, teacherFinderMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Create(module) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldEditCorrectly()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();
			Mock<IObjectFinderService<Exam>> examFinderMock = new Mock<IObjectFinderService<Exam>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IObjectFinderService<Teacher>> teacherFinderMock = new Mock<IObjectFinderService<Teacher>>();

			ModuleCreateUpdateViewModel module = new ModuleCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Exam>();
			});

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			teacherFinderMock.Setup(m => m.GetObjects(It.IsAny<string[]>())).Returns((string[] ids) =>
			{
				return new List<Teacher>();
			});

			moduleServiceMock.Setup(m => m.Update(It.IsAny<Module>())).Returns((ModuleCreateUpdateViewModel model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.OsirisCode) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, teacherServiceMock.Object, examFinderMock.Object, examServiceMock.Object, teacherFinderMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Edit(module) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void ShouldDeleteCorrectly()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();
			Mock<IObjectFinderService<Exam>> examFinderMock = new Mock<IObjectFinderService<Exam>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IObjectFinderService<Teacher>> teacherFinderMock = new Mock<IObjectFinderService<Teacher>>();

			Module module = new Module()
			{
				Id = 100,
				Name = "Server-side web programming project",
				Description = @"1. Inleiding
De opleiding informatica is zo ingericht dat je je na de propedeuse verder gaat verdiepen in softwareontwikkeling. In periode IVT2.1 heb je een start gemaakt met server-side web-ontwikkeling met ASP.net MVC Core en UX-design.

In korte tijd heb je al erg veel geleerd en in de weken 4 t/m 7 ga je de vaardigheden toepassen in een project. Samen met een veelal externe opdrachtgever realiseer je een opdracht rond een web-applicatie in ASP.net. Je gaat werken in een team van studenten, waarin ieder zijn rol gaat uitvoeren. Die rollen kunnen ook rouleren, zodat iedereen verschillende verantwoordelijkheden krijgt.

Je gaat in teamverband en met gebruik van de agile ontwikkelmethode Scrum een project uitvoeren. Je laat zien, dat je de die werkwijze nog steeds kunt toepassen. De eisen waaraan de applicatie moet voldoen spreek je af met de product owner. Aan het einde van elke sprint volgt een oplevering waarin je met je groep jullie resultaat presenteert.

Bij het uitvoeren van het project gebruik je je technische vaardigheden, en je past je professionele vaardigheden toe. Presenteren, rapporteren en samenwerken zijn vaardigheden die minstens zo belangrijk zijn als je vaardigheid om een applicatie te maken. Daarbij gebruik je ook gereedschappen om samen te werken. Je volgt het DevOps werkwijze met configuration management via Git, continuous integration, continuous testing en automatic deployment. Voor dit gehele proces (inclusief Scrum) gebruik je Microsoft Team Foundation Services.",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			moduleServiceMock.Setup(m => m.FindById(It.IsAny<int>(), It.IsAny<string[]>())).Returns(module);

			moduleServiceMock.Setup(m => m.Delete(It.IsAny<Module>())).Returns((Module model) =>
			{
				return 1;
			});

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, teacherServiceMock.Object, examFinderMock.Object, examServiceMock.Object, teacherFinderMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			RedirectToActionResult result = controller.Delete(module.Id) as RedirectToActionResult;

			Assert.Equal("Index", result?.ActionName);
		}

		[Fact]
		public void CannotCreateWithMissingValues()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();
			Mock<IObjectFinderService<Exam>> examFinderMock = new Mock<IObjectFinderService<Exam>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IObjectFinderService<Teacher>> teacherFinderMock = new Mock<IObjectFinderService<Teacher>>();

			ModuleCreateUpdateViewModel module = new ModuleCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Server-side web programming project",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Exam>();
			});

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			moduleServiceMock.Setup(m => m.Insert(It.IsAny<Module>())).Returns((ModuleCreateUpdateViewModel model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.OsirisCode) && !string.IsNullOrWhiteSpace(model.Description))
				{
					return 1;
				}

				return 0;
			});


			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, teacherServiceMock.Object, examFinderMock.Object, examServiceMock.Object, teacherFinderMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Create(module) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

		[Fact]
		public void CannotEditWithMissingValues()
		{
			Mock<IGenericService<Module>> moduleServiceMock = new Mock<IGenericService<Module>>();
			Mock<IGenericService<Teacher>> teacherServiceMock = new Mock<IGenericService<Teacher>>();
			Mock<IGenericService<Goal>> goalServiceMock = new Mock<IGenericService<Goal>>();
			Mock<IGenericService<Exam>> examServiceMock = new Mock<IGenericService<Exam>>();
			Mock<IObjectFinderService<Exam>> examFinderMock = new Mock<IObjectFinderService<Exam>>();
			Mock<IObjectFinderService<Goal>> goalFinderMock = new Mock<IObjectFinderService<Goal>>();
			Mock<IObjectFinderService<Teacher>> teacherFinderMock = new Mock<IObjectFinderService<Teacher>>();

			ModuleCreateUpdateViewModel module = new ModuleCreateUpdateViewModel()
			{
				Id = 100,
				Name = "Server-side web programming project",
				OsirisCode = "EIIN-SSWPRP",
				Goals =
				{
					new Goal()
					{
						Bloom = "Apply",
				Description = @"Kan C# en het ASP.NET platform toepassen, zodanig dat hij een  webapplicatie kan realiseren in een team:
Microsoft - MVC Framework
View Engine (Razor) C#
Visual Studio als IDE"
					}
				}
			};

			ClaimsPrincipal identity = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.NameIdentifier, "123")
			}));

			examFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Exam>();
			});

			goalFinderMock.Setup(m => m.GetObjects(It.IsAny<int[]>())).Returns((int[] ids) =>
			{
				return new List<Goal>();
			});

			teacherFinderMock.Setup(m => m.GetObjects(It.IsAny<string[]>())).Returns((string[] ids) =>
			{
				return new List<Teacher>();
			});

			moduleServiceMock.Setup(m => m.Update(It.IsAny<Module>())).Returns((ModuleCreateUpdateViewModel model) =>
			{
				if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.OsirisCode) && !string.IsNullOrWhiteSpace(model.Description) && !string.IsNullOrWhiteSpace(model.Goals.ElementAt(0).Bloom))
				{
					return 1;
				}

				return 0;
			});

			ModuleController controller = new ModuleController(null, moduleServiceMock.Object, goalServiceMock.Object, goalFinderMock.Object, teacherServiceMock.Object, examFinderMock.Object, examServiceMock.Object, teacherFinderMock.Object)
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext()
					{
						User = identity
					}
				}
			};

			ViewResult result = controller.Edit(module) as ViewResult;

			Assert.NotNull(result);
			Assert.NotNull(result.Model);
			Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "Edit");
		}

	}
}
