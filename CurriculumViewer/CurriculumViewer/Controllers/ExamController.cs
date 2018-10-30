using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for exams.
    /// </summary>
    [Authorize]
    public class ExamController : Controller
    {
		private IGenericService<Exam> examService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExamController"/> class.
		/// </summary>
		/// <param name="examService">Provides specific data operations for the <see cref="Exam"/> model.</param>
		/// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public ExamController(IGenericService<Exam> examService)
		{
			this.examService = examService;
		}

		// GET: Exam
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
		{
			return View(examService.FindAll(new string[] { "ResponsibleTeacher", "Module" }));
		}

		// GET: Exam/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the exam.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
		{
			return View(examService.FindById(id, new string[] { "ResponsibleTeacher", "Module" }));
		}

		// GET: Exam/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Create"/> action method.</returns>
		public IActionResult Create()
		{
			return View();
		}

		// POST: Exam/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create(Exam)"/> view to the response.
		/// </summary>
		/// <param name="exam">The exam to create.</param>
		/// <returns>A view of the <see cref="Create(Exam)"/> action method.</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Exam exam)
		{
			IActionResult actionResult = View(exam);

			if (!ModelState.IsValid)
			{
				actionResult = View(exam);
			}
			else if (examService.Insert(exam) == 1)
			{
				actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// GET: Exam/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the meal to edit.</param>
		/// <returns>A view of the <see cref="Edit(int)"/> action method.</returns>
		public IActionResult Edit(int id)
		{
			return View(examService.FindById(id));
		}

		// POST: Exam/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(Exam)"/> view to the response.
		/// </summary>
		/// <param name="exam">The exam to edit.</param>
		/// <returns>A view of the <see cref="Edit(Exam)"/> action method.</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Exam exam)
		{
			IActionResult actionResult = View(exam);

			if (!ModelState.IsValid)
			{
				actionResult = View(exam);
			}
			else if (examService.Update(exam) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// POST: Exam/Delete/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Delete(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the exam to delete.</param>
		/// <returns>A view of the <see cref="Delete(int)"/> action method.</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
		{
			Exam exam = examService.FindById(id);

			if (examService.Delete(exam) == 1)
			{
                return RedirectToAction(nameof(Index));
			}

            return View("Error");
		}
	}
}