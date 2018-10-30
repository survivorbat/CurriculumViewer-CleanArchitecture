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
    [Route("api/v1/logitems")]
    [ApiController]
    public class LogItemController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogItemController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public LogItemController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Log Items
        /// </summary>
        /// <returns>All Log Items</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Log Item</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet(Name = LogItemRoutes.GET_LOGITEMS)]
        public ActionResult<IEnumerable<LogItem>> Get()
        {
            IEnumerable<LogItem> data = dataService.FindAll<LogItem>(STDIncludes.LogItems).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Log Item by ID
        /// </summary>
        /// <param name="id">The Log Item ID to retrieve</param>
        /// <returns>The speficied Log Item</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Log Item could not be found</response>
        /// <response code="200">Returns the speficied Log Item</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}", Name = LogItemRoutes.GET_LOGITEM)]
        public ActionResult<LogItem> Get(int id)
        {
            LogItem result = dataService.FindById<LogItem>(id, STDIncludes.LogItems);

            if (result == null)
            {
                return NotFound("Logitem not found");
            }

            return new OkObjectResult(result);
        }
    }
}
