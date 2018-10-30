using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for goals.
    /// </summary>
    [Authorize]
    public class LearningLineController : Controller
    {
        private IGenericService<LearningLine> learningLineService;
        private IGenericService<Goal> goalService;
        private IObjectFinderService<Goal> goalFinder;
        private IManyToManyMapperService<LearningLine, LearningLineGoal, Goal> mapperService;
        private ApplicationUser applicationUser;

		/// <summary>
		/// Initializes a new instance of the <see cref="LearningLineController"/> class.
		/// </summary>
		/// <param name="goalService">Provides specific data operations for the <see cref="Goal"/> model.</param>
		/// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public LearningLineController(IGenericService<LearningLine> learningLineService, IGenericService<Goal> goalService, IObjectFinderService<Goal> goalFinder, IManyToManyMapperService<LearningLine, LearningLineGoal, Goal> mapperService)
        {
            this.learningLineService = learningLineService;
            this.goalService = goalService;
            this.mapperService = mapperService;
            this.goalFinder = goalFinder;
        }

		// GET: Goal
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
        {
            return View(learningLineService.FindAll());
        }

		// GET: Goal/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the goal.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
        {
            return View(learningLineService.FindById(id, new string[] { "Goals.Goal" }));
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
        public IActionResult Create(LearningLineCreateUpdateViewModel learningLine)
		{
			IActionResult actionResult = View(learningLine);
			string[] goals = Array.ConvertAll<int, string>(learningLine.GoalsIds.ToArray(), e => e.ToString());

			learningLine.Goals = mapperService.GetMappedEntities(learningLine, goalFinder.GetObjects(goals));

			if (!ModelState.IsValid || !goalFinder.AreIdsValid(goals))
			{
				actionResult = View("Error");
			}
			else if (learningLineService.Insert(learningLine) == 1)
			{
				actionResult = RedirectToAction(nameof(Index));
			}

			ViewData["Goals"] = goalService.FindAll();

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

            ViewData["Goals"] = goalService.FindAll();

            LearningLineCreateUpdateViewModel llcuvm = new LearningLineCreateUpdateViewModel();
		    LearningLine ll = learningLineService.FindById(id, new string[] { "Goals.Goal" });

		    llcuvm.GoalsIds = ll.Goals.Select(e => e.GoalId) as List<int>;
		    llcuvm.Goals = ll.Goals;
		    llcuvm.Name = ll.Name;

            if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else
			{
				actionResult = View(llcuvm);
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
        public IActionResult Edit(LearningLineCreateUpdateViewModel learningLine)
        {
            string[] goals = Array.ConvertAll<int, string>(learningLine.GoalsIds.ToArray(), e => e.ToString());

            learningLine.Goals = mapperService.GetMappedEntities(learningLine, goalFinder.GetObjects(goals));

            IActionResult actionResult = View(learningLine);

            if (!ModelState.IsValid || !goalFinder.AreIdsValid(goals))
			{
				actionResult = View("Error");
			}
			else if (learningLineService.Update(learningLine) == 1)
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
			LearningLine learningLine = learningLineService.FindById(id);
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (learningLineService.Delete(learningLine) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}
    }
}