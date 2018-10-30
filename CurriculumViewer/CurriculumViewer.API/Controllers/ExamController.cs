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
    [Route("api/v1/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public ExamController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Exams
        /// </summary>
        /// <returns>All Exams</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Exam</response>  
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [HttpGet(Name = ExamRoutes.GET_EXAMS)]
        public ActionResult<IEnumerable<Exam>> Get()
        {
            IEnumerable<Exam> data = dataService.FindAll<Exam>(STDIncludes.Exams).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Exam by ID
        /// </summary>
        /// <param name="id">The Exam ID to retrieve</param>
        /// <returns>The speficied Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = ExamRoutes.GET_EXAM)]
        public ActionResult<Exam> Get(int id)
        {
            Exam result = dataService.FindById<Exam>(id, STDIncludes.Exams);

            if (result == null)
            {
                return NotFound("Exam not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Exam
        /// </summary>
        /// <param name="value">The created Exam object</param>
        /// <returns>The newly created Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Exam could not be created</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost(Name = ExamRoutes.POST_EXAM)]
        public ActionResult<Exam> Post([FromBody] ExamViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(value.ResponsibleTeacher);
            Module module = dataService.FindById<Module>(value.Module);

            if (teacher == null)
            {
                return NotFound("Teacher not found");
            }
            else if (module == null)
            {
                return NotFound("Module not found");
            }

            Exam exam = new Exam
            {
                AttemptOne = value.AttemptOne,
                AttemptTwo = value.AttemptTwo,
                Compensatable = value.Compensatable,
                Language = value.Language,
                Duration = new TimeSpan(value.DurationInMinutes * 60 * 1000),
                EC = value.EC,
                ExamType = value.ExamType,
                GradeType = value.GradeType,
                Module = module,
                ResponsibleTeacher = teacher
            };

            if (dataService.Insert<Exam>(exam) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(exam);
        }

        /// <summary>
        /// Updates an existing Exam
        /// </summary>
        /// <param name="id">The Exam ID to update</param>
        /// <param name="value">The updated Exam object</param>
        /// <returns>The updated Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="400">If the specified Exam could not be updated</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpPut("{id}", Name = ExamRoutes.PUT_EXAM)]
        public ActionResult<Exam> Put(int id, [FromBody] ExamViewModel value)
        {
            Exam exam = dataService.FindById<Exam>(id);

            if (exam == null)
            {
                return NotFound("Exam not found");
            }

            Teacher teacher = dataService.FindById<Teacher>(value.ResponsibleTeacher);
            Module module = dataService.FindById<Module>(value.Module);

            exam.AttemptOne = value.AttemptOne;
            exam.AttemptTwo = value.AttemptTwo;
            exam.Compensatable = value.Compensatable;
            exam.Duration = new TimeSpan(value.DurationInMinutes * 60 * 1000);
            exam.EC = value.EC;
            exam.Language = value.Language;
            exam.ExamType = value.ExamType;
            exam.GradeType = value.GradeType;
            exam.Module = module;
            exam.ResponsibleTeacher = teacher;

            if (dataService.Update<Exam>(exam) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(exam);
        }

        /// <summary>
        /// Deletes an existing Exam
        /// </summary>
        /// <param name="id">The Exam ID to delete</param>
        /// <returns>The deleted Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}", Name = ExamRoutes.DELETE_EXAM)]
        public ActionResult<Exam> Delete(int id)
        {
            Exam result = dataService.FindById<Exam>(id);

            if (result == null)
            {
                return NotFound("Exam not found");
            }

            if (dataService.Delete(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }
    }
}
