using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for courses.
    /// </summary>
    [Authorize]
    public class CourseController : Controller
    {
        private IGenericService<Course> courseService;
        private readonly IGenericService<Module> moduleService;
        private IObjectFinderService<Module> moduleFinder;
        private IManyToManyMapperService<Course, CourseModule, Module> manyToManyMapper;
        private IGenericService<ExamProgram> examprogramService;
        private IGenericService<Teacher> teacherService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseController"/> class.
        /// </summary>
        /// <param name="courseService">Provides specific data operations for the <see cref="Course"/> model.</param>
        /// <param name="moduleService">Provides specific data operations for the <see cref="Module"/> model.</param>
        /// <param name="moduleFinder">Provides specific data operations for module objects.</param>
        /// <param name="manyToManyMapper">Maps entities for Many-To-Many relations</param>
        /// <param name="activityLoggerService">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
        public CourseController(IGenericService<Course> courseService, IGenericService<Module> moduleService, IObjectFinderService<Module> moduleFinder, IManyToManyMapperService<Course, CourseModule, Module> manyToManyMapper, IGenericService<ExamProgram> examProgramService, IGenericService<Teacher> teacherService) 
		{
            this.courseService = courseService;
            this.moduleService = moduleService;
            this.moduleFinder = moduleFinder;
            this.manyToManyMapper = manyToManyMapper;
            this.examprogramService = examProgramService;
            this.teacherService = teacherService;
        }

		// GET: Course
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
        {
            return View(courseService.FindAll(new string[] { "Mentor", "Modules.Module.Exams", "Modules.Module.Goals" }));
        }

		// GET: Course/Details/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Detail(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the course.</param>
		/// <returns>A view of the <see cref="Detail(int)"/> action method.</returns>
		public IActionResult Details(int id)
        {
            return View(courseService.FindById(id, new string[] { "Modules.Module.Teacher", "Mentor", "Modules.Module.Exams", "Modules.Module.Goals", "ExamProgram" }));
        }

		// GET: Course/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Create"/> action method.</returns>
		public IActionResult Create()
        {
            ViewData["Modules"] = moduleService.FindAll();
            ViewData["Examprograms"] = examprogramService.FindAll();
            ViewData["Teachers"] = teacherService.FindAll();
            return View();
        }

		// POST: Course/Create
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Create(CourseCreateUpdateViewModel)"/> view to the response.
		/// </summary>
		/// <param name="course">The course to create.</param>
		/// <returns>A view of the <see cref="Create(CourseCreateUpdateViewModel)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateUpdateViewModel course)
        {
			course.Modules = manyToManyMapper.GetMappedEntities(course, moduleFinder.GetObjects(course.ModuleIds.ToArray()).ToList());
            course.ExamProgram = examprogramService.FindById(course.ExamProgramId);
            course.Mentor = teacherService.FindById(course.MentorId);
			IActionResult actionResult = View(course);

			if (!ModelState.IsValid || !moduleFinder.AreIdsValid(course.ModuleIds.ToArray()))
			{
				actionResult = View("Error");
			}
			else if(courseService.Insert(course) == 1)
            {
				actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;   
        }

		// GET: Course/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the course to edit.</param>
		/// <returns>A view of the <see cref="Edit(int)"/> action method.</returns>
		public IActionResult Edit(int id)
        {
			IActionResult actionResult = View();
            ViewData["Examprograms"] = examprogramService.FindAll();
            ViewData["Modules"] = moduleService.FindAll();
            ViewData["Teachers"] = teacherService.FindAll();

            Course resultObject = courseService.FindById(id, new string[] { "Mentor", "ExamProgram", "Modules" });
            CourseCreateUpdateViewModel result = new CourseCreateUpdateViewModel()
            {
                Name = resultObject.Name,
                Description = resultObject.Description,
                ExamProgram = resultObject.ExamProgram,
                Mentor = resultObject.Mentor,
                StudyYear = resultObject.StudyYear,
                Modules = resultObject.Modules
            };
			actionResult = View(result);

			return actionResult;
		}

		// POST: Course/Edit/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Edit(Course)"/> view to the response.
		/// </summary>
		/// <param name="course">The course to edit.</param>
		/// <returns>A view of the <see cref="Edit(Course)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CourseCreateUpdateViewModel course)
        {
            course.Modules = manyToManyMapper.GetMappedEntities(course, moduleFinder.GetObjects(course.ModuleIds.ToArray()).ToList());
            course.ExamProgram = examprogramService.FindById(course.ExamProgramId);
            course.Mentor = teacherService.FindById(course.MentorId);
            IActionResult actionResult = View(course);

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (courseService.Update(course) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}

		// POST: Course/Delete/5
		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Delete(int)"/> view to the response.
		/// </summary>
		/// <param name="id">The ID of the course to delete.</param>
		/// <returns>A view of the <see cref="Delete(int)"/> action method.</returns>
		[HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
			Course course = courseService.FindById(id, new string[] { "ExamProgram" });
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (courseService.Delete(course) == 1)
			{
                actionResult = RedirectToAction(nameof(Index));
			}

			return actionResult;
		}
    }
}