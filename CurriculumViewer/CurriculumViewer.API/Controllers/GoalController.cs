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
    [Route("api/v1/goals")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoalController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public GoalController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Goals
        /// </summary>
        /// <returns>All Goals</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Goal</response>  
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [HttpGet(Name = GoalRoutes.GET_GOALS)]
        public ActionResult<IEnumerable<Goal>> Get()
        {
            IEnumerable<Goal> data = dataService.FindAll<Goal>(STDIncludes.Goals).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Goal by ID
        /// </summary>
        /// <param name="id">The Goal ID to retrieve</param>
        /// <returns>The speficied Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = GoalRoutes.GET_GOAL)]
        public ActionResult<Goal> Get(int id)
        {
            Goal result = dataService.FindById<Goal>(id, STDIncludes.Goals);

            if (result == null)
            {
                return NotFound("Goal not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Goal
        /// </summary>
        /// <param name="value">The created Goal object</param>
        /// <returns>The newly created Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Goal could not be created</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost(Name = GoalRoutes.POST_GOAL)]
        public ActionResult<Goal> Post([FromBody] GoalViewModel value)
        {
            Goal goal = new Goal
            {
                Bloom = value.Bloom,
                Description = value.Description
            };

            if (dataService.Insert<Goal>(goal) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(goal);
        }

        /// <summary>
        /// Updates an existing Goal
        /// </summary>
        /// <param name="id">The Goal ID to update</param>
        /// <param name="value">The updated Goal object</param>
        /// <returns>The updated Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="400">If the specified Goal could not be updated</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = GoalRoutes.PUT_GOAL)]
        public ActionResult<Goal> Put(int id, [FromBody] GoalViewModel value)
        {
            Goal goal = dataService.FindById<Goal>(id);

            if (goal == null)
            {
                return NotFound("Goal not found");
            }

            goal.Description = value.Description;
            goal.Bloom = value.Bloom;

            if (dataService.Update<Goal>(goal) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(goal);
        }

        /// <summary>
        /// Deletes an existing Goal
        /// </summary>
        /// <param name="id">The Goal ID to delete</param>
        /// <returns>The deleted Goal</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Goal could not be found</response>
        /// <response code="200">Returns the speficied Goal</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}", Name = GoalRoutes.DELETE_GOAL)]
        public ActionResult<Goal> Delete(int id)
        {
            Goal result = dataService.FindById<Goal>(id);

            if (result == null)
            {
                return NotFound("Goal not found");
            }

            if (dataService.Delete(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }
    }
}
