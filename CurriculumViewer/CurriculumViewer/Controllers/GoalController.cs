using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for goals.
    /// </summary>
    [Authorize]
    public class GoalController : Controller
    {
        private IGenericService<Goal> goalService;

		/// <summary>
		/// Initializes a new instance of the <see cref="GoalController"/> class.
		/// </summary>
		/// <param name="goalService">Provides specific data operations for the <see cref="Goal"/> model.</param>
		/// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public GoalController(IGenericService<Goal> goalService)
        {
            this.goalService = goalService;
        }

		// GET: Goal
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
        {
            return View(goalService.FindAll());
        }

		// GET: Goal/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the goal.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
        {
            return View(goalService.FindById(id, new string[] { "Module", "InLearningLines.LearningLine" }));
        }

		// GET: Goal/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Create"/> action method.</returns>
		public ActionResult Create()
        {
			ViewData["Goals"] = goalService.FindAll();
			return View();
		}

		// POST: Goal/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create(Goal)"/> view to the response.
		/// </summary>
		/// <param name="goal">The goal to create.</param>
		/// <returns>A view of the <see cref="Create(Goal)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Goal goal)
        {
			IActionResult actionResult = View(goal);

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (goalService.Insert(goal) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// GET: Goal/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the goal to edit.</param>
		/// <returns>A view of the <see cref="Edit(int)"/> action method.</returns>
		public IActionResult Edit(int id)
		{
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else
			{
				actionResult = View(goalService.FindById(id));
			}

			return actionResult;
		}

		// POST: Goal/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(Goal)"/> view to the response.
		/// </summary>
		/// <param name="module">The goal to edit.</param>
		/// <returns>A view of the <see cref="Edit(Goal)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Goal goal)
        {
			IActionResult actionResult = View(goal);

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (goalService.Update(goal) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// POST: Goal/Delete/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Delete(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the goal to delete.</param>
		/// <returns>A view of the <see cref="Delete(int)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
			Goal goal = goalService.FindById(id);
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (goalService.Delete(goal) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}
    }
}