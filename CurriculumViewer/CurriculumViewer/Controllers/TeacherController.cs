using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for teachers.
    /// </summary>
    [Authorize]
    public class TeacherController : Controller
    {
        private IGenericService<Teacher> teacherService;

		/// <summary>
		/// Initializes a new instance of the <see cref="TeacherController"/> class.
		/// </summary>
		/// <param name="teacherService">Provides specific data operations for the <see cref="Teacher"/> model.</param>
		/// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public TeacherController(IGenericService<Teacher> teacherService)
        {
            this.teacherService = teacherService;
        }

		// GET: Teacher
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
        {
            return View(teacherService.FindAll());
        }

		// GET: Teacher/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the teacher.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
		{
			return View(teacherService.FindById(id, new string[] { "ResponsibleForExams.Module", "ResponsibleForModules.Module", "ResponsibleForCourses" }));
		}

        // GET: Teacher/Create
        /// <summary>
        /// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create"/> view to the response.
        /// </summary>
        /// <returns>A view of the <see cref="Create"/> action method.</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
		{
			return View();
		}

		// POST: Teacher/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create(Teacher)"/> view to the response.
		/// </summary>
		/// <param name="module">The teacher to create.</param>
		/// <returns>A view of the <see cref="Create(Teacher)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Create(Teacher teacher)
		{
			IActionResult actionResult = View(teacher);

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (teacherService.Insert(teacher) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

        // GET: Teacher/Edit/5
        /// <summary>
        /// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(int)"/> view to the response.
        /// </summary>
        /// <param name="id">The ID of the teacher to edit.</param>
        /// <returns>A view of the <see cref="Edit(int)"/> action method.</returns>
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
		{
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else
			{
				actionResult = View(teacherService.FindById(id));
			}

			return actionResult;
		}

		// POST: Teacher/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(Module)"/> view to the response.
		/// </summary>
		/// <param name="teacher">The teacher to edit.</param>
		/// <returns>A view of the <see cref="Edit(Module)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Edit(Teacher teacher)
        {
			IActionResult actionResult = View(teacher);

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (teacherService.Update(teacher) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// POST: Teacher/Delete/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Delete(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the teacher to delete.</param>
		/// <returns>A view of the <see cref="Delete(int)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
		{
			Teacher teacher = teacherService.FindById(id);
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (teacherService.Delete(teacher) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}
	}
}