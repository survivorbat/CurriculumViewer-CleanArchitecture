using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.API.v1.Constants;
using CurriculumViewer.API.v1.Models.ViewModels;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.API.v1.Controllers
{
    [Route("api/v1/learninglines")]
    [ApiController]
    public class LearningLineController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        private IManyToManyMapperService<LearningLine, LearningLineGoal, Goal> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LearningLineController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        /// <param name="mapper">Map entities to one or another.</param>
        public LearningLineController(IGenericServiceV2 dataService, IManyToManyMapperService<LearningLine, LearningLineGoal, Goal> mapper)
        {
            this.dataService = dataService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all Learning Lines
        /// </summary>
        /// <returns>All Learning Lines</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Learning Line</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet(Name = LearningLineRoutes.GET_LEARNINGLINES)]
        public ActionResult<IEnumerable<LearningLine>> Get()
        {
            IEnumerable<LearningLine> data = dataService.FindAll<LearningLine>(STDIncludes.LearningLines).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Learning Line by ID
        /// </summary>
        /// <param name="id">The Learning Line ID to retrieve</param>
        /// <returns>The speficied Learning Line</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Learning Line could not be found</response>
        /// <response code="200">Returns the speficied Learning Line</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}", Name = LearningLineRoutes.GET_LEARNINGLINE)]
        public ActionResult<LearningLine> Get(int id)
        {
            LearningLine result = dataService.FindById<LearningLine>(id, STDIncludes.LearningLines);

            if (result == null)
            {
                return NotFound("Learningline not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Learning Line
        /// </summary>
        /// <param name="value">The created Learning Line object</param>
        /// <returns>The newly created Learning Line</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Learning Line could not be created</response>
        /// <response code="200">Returns the speficied Learning Line</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost(Name = LearningLineRoutes.POST_LEARNINGLINE)]
        public ActionResult<LearningLine> Post([FromBody] LearningLineViewModel value)
        {
            LearningLine line = new LearningLine
            {
                Name = value.Name
            };

            if (dataService.Insert<LearningLine>(line) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(line);
        }

        /// <summary>
        /// Updates an existing Learning Line
        /// </summary>
        /// <param name="id">The Learning Line ID to update</param>
        /// <param name="value">The updated Learning Line object</param>
        /// <returns>The updated Learning Line</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Learning Line could not be found</response>
        /// <response code="400">If the specified Learning Line could not be updated</response>
        /// <response code="200">Returns the speficied Learning Line</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}", Name = LearningLineRoutes.PUT_LEARNINGLINE)]
        public ActionResult<LearningLine> Put(int id, [FromBody] LearningLine value)
        {
            LearningLine line = dataService.FindById<LearningLine>(id);

            line.Name = value.Name;

            if (dataService.Update<LearningLine>(line) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(line);
        }

        /// <summary>
        /// Deletes an existing Learning Line
        /// </summary>
        /// <param name="id">The Learning Line ID to delete</param>
        /// <returns>The deleted Learning Line</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Learning Line could not be found</response>
        /// <response code="200">Returns the speficied Learning Line</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}", Name = LearningLineRoutes.DELETE_LEARNINGLINE)]
        public ActionResult<LearningLine> Delete(int id)
        {
            LearningLine result = dataService.FindById<LearningLine>(id);

            if (result == null)
            {
                return NotFound("Learningline not found");
            }

            if (dataService.Delete(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get all Goals linked to an Learning Line
        /// </summary>
        /// <param name="id">The Learning Line ID</param>
        /// <returns>All Goals of the specified Learning Line</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Goals</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/goals", Name = LearningLineRoutes.GET_LEARNINGLINE_GOALS)]
        public ActionResult<IEnumerable<Goal>> GetGoals(int id)
        {
            LearningLine line = dataService.FindById<LearningLine>(id, new string[] { "Goals.Goal" });

            if (line == null)
            {
                return NotFound("Learningline not found");
            }

            return new OkObjectResult(line.Goals.Select(e => e.Goal));
        }

        /// <summary>
        /// Get a Goal linked to an Learning Line by ID
        /// </summary>
        /// <param name="id">The Learning Line ID</param>
        /// <param name="goalId">The Goal ID to retrieve</param>
        /// <returns>The speficied Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/goals/{goalid}", Name = LearningLineRoutes.GET_LEARNINGLINE_GOALS_GOAL)]
        public ActionResult<Goal> GetGoal(int id, int goalId)
        {
            LearningLine line = dataService.FindById<LearningLine>(id, new string[] { "Goals.Goal" });

            if (line == null)
            {
                return NotFound("Learningline not found");
            }

            foreach (Goal goal in line.Goals.Select(e => e.Goal))
            {
                if (goal.Id == goalId)
                {
                    return new OkObjectResult(goal);
                }
            }

            return NotFound("Goal not found");
        }

        /// <summary>
        /// Add a new Goal to an existing Learning Line
        /// </summary>
        /// <param name="id">The Learning Line ID to add a Goal to</param>
        /// <param name="goalId">The Goal ID</param>
        /// <returns>The newly added Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Goal could not be created</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("{id}/goals", Name = LearningLineRoutes.POST_LEARNINGLINE_GOALS)]
        public ActionResult<IEnumerable<Goal>> PostGoal(int id, int goalId)
        {
            LearningLine line = dataService.FindById<LearningLine>(id, new string[] { "Goals.Goal" });
            Goal goal = dataService.FindById<Goal>(goalId);

            if (goal == null)
            {
                return NotFound("Goal not found");
            }
            else if (line == null)
            {
                return NotFound("Learningline not found");
            }

            line.Goals.Add(mapper.GetMappedEntities(line, new Goal[] { goal }).First());

            if (dataService.Update<LearningLine>(line) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(line);
        }

        /// <summary>
        /// Removes an existing Goal from a Learning Line
        /// </summary>
        /// <param name="id">The Learning Line ID</param>
        /// <param name="goalId">The Goal ID to remove</param>
        /// <returns>The removed Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="400">If the specified Goal could not be removed</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}/goals/{goalid}", Name = LearningLineRoutes.DELETE_LEARNINGLINE_GOALS_GOAL)]
        public ActionResult<IEnumerable<Goal>> DeleteGoal(int id, int goalId)
        {
            LearningLine line = dataService.FindById<LearningLine>(id, new string[] { "Goals.Goal" });
            Goal goal = dataService.FindById<Goal>(goalId);

            if (goal == null)
            {
                return NotFound("Goal not found");
            }
            else if (line == null)
            {
                return NotFound("Learningline not found");
            }

            foreach (LearningLineGoal linegoal in line.Goals)
            {
                if (linegoal.GoalId == goalId)
                {
                    line.Goals.Remove(linegoal);
                    break;
                }
            }

            if (dataService.Update<LearningLine>(line) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(line);
        }
    }
}
