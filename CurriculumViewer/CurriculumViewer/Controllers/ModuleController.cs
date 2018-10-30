using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net.Http;
using Xceed.Words.NET;
using System.IO;
using System;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for modules.
    /// </summary>
    [Authorize]
    public class ModuleController : Controller
    {
		private IGenericService<Module> moduleService;
		private IGenericService<Goal> goalService;
		private IObjectFinderService<Goal> goalFinder;
        private IGenericService<Teacher> teacherService;
        private IGeneratorService<DocX> guideGeneratorService;
        private IObjectFinderService<Exam> examFinder;
        private IGenericService<Exam> examService;
        private IObjectFinderService<Teacher> teacherFinder;

		/// <summary>
		/// Initializes a new instance of the <see cref="ModuleController"/> class.
		/// </summary>
		/// <param name="moduleService">Provides specific data operations for the <see cref="Module"/> model.</param>
		/// <param name="goalService">Provides specific data operations for the <see cref="Goal"/> model.</param>
		/// <param name="goalFinder">Provides specific data operations for goal objects.</param>
		/// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public ModuleController(IGeneratorService<DocX> guideGeneratorService, IGenericService<Module> moduleService, IGenericService<Goal> goalService, IObjectFinderService<Goal> goalFinder, IGenericService<Teacher> teacherService, IObjectFinderService<Exam> examFinder, IGenericService<Exam> examService, IObjectFinderService<Teacher> teacherFinder)
		{
		    this.guideGeneratorService = guideGeneratorService;
			this.moduleService = moduleService;
			this.goalService = goalService;
			this.goalFinder = goalFinder;
            this.teacherService = teacherService;
            this.examFinder = examFinder;
            this.examService = examService;
            this.teacherFinder = teacherFinder;
		}

		// GET: Module
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
        {
            return View(moduleService.FindAll());
        }

		// GET: Module/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the module.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
        {
            return View(moduleService.FindById(id, new string[] { "InCourses.Course", "Goals", "Exams.ResponsibleTeacher", "Exams.Module" }));
        }

		// GET: Module/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Create"/> action method.</returns>
		public IActionResult Create()
        {
			ViewData["g"] = goalService.FindAll();
            ViewData["t"] = teacherService.FindAll();
            ViewData["e"] = examService.FindAll(new string[] { "Module" });

            return View();
		}

		// POST: Module/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create(Module)"/> view to the response.
		/// </summary>
		/// <param name="module">The module to create.</param>
		/// <returns>A view of the <see cref="Create(Module)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ModuleCreateUpdateViewModel module)
        {
			IActionResult actionResult = View(module);

            module.Goals = goalFinder.GetObjects(module.GoalsIds.ToArray()).ToList();
            module.Exams = examFinder.GetObjects(module.ExamsIds.ToArray()).ToList();
            module.Teacher = teacherService.FindById(module.TeacherId);

            if (!ModelState.IsValid)
			{
                ViewData["g"] = goalService.FindAll();
                ViewData["t"] = teacherService.FindAll();
                ViewData["e"] = examService.FindAll(new string[] { "Module" });
                return View(module);
            }
			else if (moduleService.Insert(module) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// GET: Module/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the module to edit.</param>
		/// <returns>A view of the <see cref="Edit(int)"/> action method.</returns>
		public IActionResult Edit(int id)
        {
			IActionResult actionResult = View();
            ViewData["g"] = goalService.FindAll();
            ViewData["t"] = teacherService.FindAll();
            ViewData["e"] = examService.FindAll(new string[] { "Module" });

            Module moduleObject = moduleService.FindById(id, new string[] { "Teacher", "Goals", "Exams" });

            ModuleCreateUpdateViewModel module = new ModuleCreateUpdateViewModel()
            {
                Name = moduleObject.Name,
                Description = moduleObject.Description,
                Exams = moduleObject.Exams,
                Goals = moduleObject.Goals,
                OsirisCode = moduleObject.OsirisCode,
                Teacher = moduleObject.Teacher
            };

            return View(module);
        }

		// POST: Module/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(Module)"/> view to the response.
		/// </summary>
		/// <param name="module">The module to edit.</param>
		/// <returns>A view of the <see cref="Edit(Module)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ModuleCreateUpdateViewModel module)
        {
			IActionResult actionResult = View(module);

            module.Goals = goalFinder.GetObjects(module.GoalsIds.ToArray()).ToList();
            module.Exams = examFinder.GetObjects(module.ExamsIds.ToArray()).ToList();
            module.Teacher = teacherFinder.GetObjects(new string[] { module.TeacherId.ToString() }).FirstOrDefault();

            if (!ModelState.IsValid)
			{
                ViewData["g"] = goalService.FindAll();
                ViewData["t"] = teacherService.FindAll();
                ViewData["e"] = examService.FindAll(new string[] { "Module" });
                return View(module);
			}
			else if (moduleService.Update(module) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
        }

		// POST: Module/Delete/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Delete(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the module to delete.</param>
		/// <returns>A view of the <see cref="Delete(int)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
			Module module = moduleService.FindById(id);
			IActionResult actionResult = View("Error");

            if (moduleService.Delete(module) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}
            return actionResult;
		}

        public ActionResult GenerateGuide(int id)
        {
            Module module = moduleService.FindById(id, new String[]{"Teacher"});
            
            using (MemoryStream ms = new MemoryStream())
            {
                FileStream imageStream = new FileStream("./wwwroot/images/logo.png", FileMode.Open,
                    FileAccess.Read);

                PdfBitmap image = new PdfBitmap(imageStream);

                //Create a new PDF document
                PdfDocument document = new PdfDocument();

                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont headerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 25);
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 13);

                //Header
                graphics.DrawString(String.Format("Academie voor Engineering en ICT"), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 0));
                graphics.DrawString(String.Format("Opleiding Informatica"), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 20));
                graphics.DrawImage(image, 350, 0, 150, 50);

                //Body
                graphics.DrawString(String.Format("Leerwijzer - {0}", module.Name), headerFont, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 100));
                graphics.DrawString(String.Format("Osiris Code - {0}", module.OsirisCode), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, 150));

                PdfTextElement textElement = new PdfTextElement(module.Description, new PdfStandardFont(PdfFontFamily.TimesRoman, 14));
                textElement.Draw(page, new RectangleF(0, 200, page.GetClientSize().Width, page.GetClientSize().Height));

                //Footer
                graphics.DrawString(String.Format("Verantwoordelijke docent: {0}", module.Teacher.FullName), font, PdfBrushes.Black, new Syncfusion.Drawing.PointF(0, page.GetClientSize().Height - 50));
                //Saving the PDF to the MemoryStream

                document.Save(ms);

                //Set the position as '0'.
                ms.Position = 0;

                return File(ms.GetBuffer(), "application/pdf", String.Format("{0}_Leerwijzer_{0}_{1}.pdf", module.OsirisCode, module.Name, DateTime.Now));
            }
        }
    }
}