using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.API.v1.Constants;
using CurriculumViewer.API.v1.Models.ViewModels;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.API.v1.Controllers
{
    /// <summary>
    /// Modules that belong to a course, modules have exams and goals.
    /// </summary>
    [Route("api/v1/modules")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public ModuleController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Modules
        /// </summary>
        /// <returns>All Modules</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Module</response>  
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [HttpGet(Name = ModuleRoutes.GET_MODULES)]
        public ActionResult<IEnumerable<Module>> Get()
        {
            IEnumerable<Module> data = dataService.FindAll<Module>(STDIncludes.Modules).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Module by ID
        /// </summary>
        /// <param name="id">The Module ID to retrieve</param>
        /// <returns>The speficied Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Module could not be found</response>
        /// <response code="200">Returns the speficied Module</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}", Name = ModuleRoutes.GET_MODULE)]
        public ActionResult<Module> Get(int id)
        {
            Module result = dataService.FindById<Module>(id, STDIncludes.Modules);

            if (result == null)
            {
                return NotFound("Module not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Module
        /// </summary>
        /// <param name="value">The created Module object</param>
        /// <returns>The newly created Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Module could not be created</response>
        /// <response code="200">Returns the speficied Module</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost(Name = ModuleRoutes.POST_MODULES)]
        public ActionResult<Module> Post([FromBody] ModuleViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(value.Teacher);

            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            Module module = new Module()
            {
                Description = value.Description,
                Name = value.Name,
                Teacher = teacher,
                OsirisCode = value.OsirisCode
            };

            if (dataService.Insert<Module>(module) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(module);
        }

        /// <summary>
        /// Updates an existing Module
        /// </summary>
        /// <param name="id">The Module ID to update</param>
        /// <param name="value">The updated Module object</param>
        /// <returns>The updated Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Module could not be found</response>
        /// <response code="400">If the specified Module could not be updated</response>
        /// <response code="200">Returns the speficied Module</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}", Name = ModuleRoutes.PUT_MODULE)]
        public ActionResult<Module> Put(int id, [FromBody] ModuleViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(value.Teacher);

            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            Module module = dataService.FindById<Module>(id);
            module.Teacher = teacher;
            module.Name = value.Name;
            module.OsirisCode = value.OsirisCode;
            module.Description = value.Description;

            if (dataService.Update<Module>(module) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(module);
        }

        /// <summary>
        /// Deletes an existing Module
        /// </summary>
        /// <param name="id">The Module ID to delete</param>
        /// <returns>The deleted Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Module could not be found</response>
        /// <response code="200">Returns the speficied Module</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}", Name = ModuleRoutes.DELETE_MODULE)]
        public ActionResult<Module> Delete(int id)
        {
            Module result = dataService.FindById<Module>(id);

            if (result == null)
            {
                return NotFound("Module not found");
            }

            if (dataService.Delete<Module>(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get all Exams linked to an Module
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <returns>All Exams of the specified Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Exams</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/exams", Name = ModuleRoutes.GET_MODULE_EXAMS)]
        public ActionResult<IEnumerable<Exam>> GetExams(int id)
        {
            Module data = dataService.FindById<Module>(id, new string[] { "Exams" });

            if (data == null)
            {
                return NotFound("Module not found");
            }

            return new OkObjectResult(data.Exams);
        }

        /// <summary>
        /// Get a Exam linked to an Module by ID
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <param name="examId">The Exam ID to retrieve</param>
        /// <returns>The speficied Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("{id}/exams", Name = ModuleRoutes.POST_MODULE_EXAMS)]
        public ActionResult<IEnumerable<Exam>> PostExams(int id, IdViewModel examId)
        {
            Module module = dataService.FindById<Module>(id, new string[] { "Exams" });
            Exam exam = dataService.FindById<Exam>(examId.Id);
            
            if (exam == null)
            {
                return NotFound("Exam not found");
            }
            else if (module == null)
            {
                return NotFound("Module not found");
            }

            module.Exams.Add(exam);

            if (dataService.Update<Module>(module) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }

        /// <summary>
        /// Add a new Exam to an existing Module
        /// </summary>
        /// <param name="id">The Module ID to add a Exam to</param>
        /// <param name="examId">The Exam ID</param>
        /// <returns>The newly added Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Exam could not be created</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/exams/{examid}", Name = ModuleRoutes.GET_MODULE_EXAMS_EXAM)]
        public ActionResult<IEnumerable<Exam>> GetExam(int id, int examId)
        {
            if (dataService.FindById<Module>(id) == null)
            {
                return NotFound("Module not found");
            }
            Exam data = dataService.FindById<Exam>(examId);

            if (data == null)
            {
                return NotFound("Exam not found");
            }
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Removes an existing Exam from a Module
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <param name="examId">The Exam ID to remove</param>
        /// <returns>The removed Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="400">If the specified Exam could not be removed</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}/exams/{examid}", Name = ModuleRoutes.DELETE_MODULE_EXAMS_EXAM)]
        public ActionResult<IEnumerable<Exam>> DeleteExams(int id, int examId)
        {
            Module module = dataService.FindById<Module>(id, new string[] { "Exams" });
            Exam exam = dataService.FindById<Exam>(examId);

            if (exam == null)
            {
                return NotFound("Exam not found");
            }
            else if (module == null)
            {
                return NotFound("Module not found");
            }

            module.Exams.Remove(exam);

            if (dataService.Update<Module>(module) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }

        /// <summary>
        /// Get all Goals linked to an Module
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <returns>All Goals of the specified Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Goals</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/goals", Name = ModuleRoutes.GET_MODULE_GOALS)]
        public ActionResult<IEnumerable<Goal>> GetGoals(int id)
        {
            Module data = dataService.FindById<Module>(id, new string[] { "Goals" });

            if (data == null)
            {
                return NotFound("Module not found");
            }
            return new OkObjectResult(data.Goals);
        }

        /// <summary>
        /// Get a Goal linked to an Module by ID
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <param name="goalId">The Goal ID to retrieve</param>
        /// <returns>The speficied Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/goals/{goalid}", Name = ModuleRoutes.GET_MODULE_GOALS_GOAL)]
        public ActionResult<IEnumerable<Goal>> GetGoals(int id, int goalId)
        {
            if (dataService.FindById<Module>(id) == null)
            {
                return NotFound("Module not found");
            }
            Goal data = dataService.FindById<Goal>(goalId);

            if (data == null)
            {
                return NotFound("Goal not found");
            }
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Add a new Goal to an existing Module
        /// </summary>
        /// <param name="id">The Module ID to add a Goal to</param>
        /// <param name="goalId">The Goal ID</param>
        /// <returns>The newly added Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Goal could not be created</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("{id}/goals", Name = ModuleRoutes.POST_MODULE_GOALS)]
        public ActionResult<IEnumerable<Goal>> PostGoal(int id, int goalId)
        {
            Module module = dataService.FindById<Module>(id, new string[] { "Goals" });
            Goal goal = dataService.FindById<Goal>(goalId);

            if (goal == null)
            {
                return NotFound("Goal not found");
            }
            else if (module == null)
            {
                return NotFound("Module not found");
            }

            module.Goals.Add(goal);

            if (dataService.Update<Module>(module) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }

        /// <summary>
        /// Delete goal off of module
        /// </summary>
        /// <param name="id">The Module ID</param>
        /// <param name="goalId">The Goal ID to remove</param>
        /// <returns>The removed Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="400">If the specified Goal could not be removed</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}/goals/{goalid}", Name = ModuleRoutes.DELETE_MODULE_GOALS_GOAL)]
        public ActionResult<IEnumerable<Goal>> DeleteGoals(int id, int goalId)
        {
            Module module = dataService.FindById<Module>(id, new string[] { "Goals" });
            Goal goal = dataService.FindById<Goal>(goalId);

            if (goal == null)
            {
                return NotFound("Goal not found");
            }
            else if (module == null)
            {
                return NotFound("Module not found");
            }

            module.Goals.Remove(goal);

            if (dataService.Update<Module>(module) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }
    }
}
