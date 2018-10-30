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
    [Route("api/v1/examprograms")]
    [ApiController]
    public class ExamProgramController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamProgramController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public ExamProgramController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Exam Programs
        /// </summary>
        /// <returns>All Exam Programs</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Exam Program</response>  
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpGet(Name = ExamProgramRoutes.GET_EXAMPROGRAMS)]
        public ActionResult<IEnumerable<ExamProgram>> Get()
        {
            IEnumerable<ExamProgram> data = dataService.FindAll<ExamProgram>(STDIncludes.ExamPrograms).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Exam Program by ID
        /// </summary>
        /// <param name="id">The Exam Program ID to retrieve</param>
        /// <returns>The speficied Exam Program</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam Program could not be found</response>
        /// <response code="200">Returns the speficied Exam Program</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}", Name = ExamProgramRoutes.GET_EXAMPROGRAM)]
        public ActionResult<ExamProgram> Get(int id)
        {
            ExamProgram result = dataService.FindById<ExamProgram>(id);

            if (result == null)
            {
                return NotFound("Examprogram not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Exam Program
        /// </summary>
        /// <param name="value">The created Exam Program object</param>
        /// <returns>The newly created Exam Program</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Exam Program could not be created</response>
        /// <response code="200">Returns the speficied Exam Program</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost(Name = ExamProgramRoutes.POST_EXAMPROGRAM)]
        public ActionResult<ExamProgram> Post([FromBody] ExamProgramViewModel value)
        {
            ExamProgram program = new ExamProgram
            {
                StartDate = value.StartDate,
                EndDate = value.EndDate
            };

            if (dataService.Insert<ExamProgram>(program) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(program);
        }

        /// <summary>
        /// Updates an existing Exam Program
        /// </summary>
        /// <param name="id">The Exam Program ID to update</param>
        /// <param name="value">The updated Exam Program object</param>
        /// <returns>The updated Exam Program</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam Program could not be found</response>
        /// <response code="400">If the specified Exam Program could not be updated</response>
        /// <response code="200">Returns the speficied Exam Program</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}", Name = ExamProgramRoutes.PUT_EXAMPROGRAM)]
        public ActionResult<ExamProgram> Put(int id, [FromBody] ExamProgramViewModel value)
        {
            ExamProgram program = dataService.FindById<ExamProgram>(id);

            if (program == null)
            {
                return NotFound("Examprogram not found!");
            }

            program.EndDate = value.EndDate;
            program.StartDate = value.StartDate;

            if (dataService.Update<ExamProgram>(program) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(program);
        }

        /// <summary>
        /// Bulk updates existing Exam Programs
        /// </summary>
        /// <param name="values">The updated Exam Program objects</param>
        /// <returns>The updated Exam Programs</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If an Exam Program could not be found</response>
        /// <response code="400">If an Exam Program could not be updated</response>
        /// <response code="200">Returns the speficied Exam Programs</response>
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("", Name = ExamProgramRoutes.PUT_EXAMPROGRAMS)]
        public ActionResult<ExamProgram> Put([FromBody] BulkExamProgramViewModel[] values)
        {
            foreach (BulkExamProgramViewModel value in values) {
                StatusCodeResult result = Put(value.Id, value).Result as StatusCodeResult;

                if (result.StatusCode != 200)
                {
                    return result;
                }
            }

            return new OkObjectResult(dataService.FindAll<ExamProgram>());
        }

        /// <summary>
        /// Bulk delete all existing Exam Programs
        /// </summary>
        /// <returns>The deleted Exam Programs</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Exam Program</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [HttpDelete("", Name = ExamProgramRoutes.DELETE_EXAMPROGRAMS)]
        public ActionResult<ExamProgram> Delete()
        {
            List<ExamProgram> examPrograms = dataService.FindAll<ExamProgram>().ToList();
            
            foreach (ExamProgram examProgram in examPrograms)
            {
                if (dataService.Delete<ExamProgram>(examProgram) != 1)
                {
                    return StatusCode(500);
                }
            }

            return new OkObjectResult(examPrograms);
        }

        /// <summary>
        /// Deletes an existing Course
        /// </summary>
        /// <param name="id">The Course ID to delete</param>
        /// <returns>The deleted Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}", Name = ExamProgramRoutes.DELETE_EXAMPROGRAM)]
        public ActionResult<ExamProgram> Delete(int id)
        {
            ExamProgram result = dataService.FindById<ExamProgram>(id);

            if (result == null)
            {
                return NotFound("ExamProgram not found");
            }

            if (dataService.Delete(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get all Courses linked to an Exam Program
        /// </summary>
        /// <returns>All Courses of the specified Exam Program</returns>
        /// <param name="id">The Exam Program ID</param>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Courses</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/courses", Name = ExamProgramRoutes.GET_EXAMPROGRAM_COURSES)]
        public ActionResult<IEnumerable<Course>> GetCourses(int id)
        {
            ExamProgram course = dataService.FindById<ExamProgram>(id, new string[] { "Courses" });

            if (course == null)
            {
                return NotFound("Examprogram not found");
            }

            return new OkObjectResult(course.Courses);
        }

        /// <summary>
        /// Get a Course linked to an Exam Program by ID
        /// </summary>
        /// <param name="id">The Exam Program ID</param>
        /// <param name="courseId">The Course ID to retrieve</param>
        /// <returns>The speficied Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpGet("{id}/courses/{courseid}", Name = ExamProgramRoutes.GET_EXAMPROGRAM_COURSES_COURSE)]
        public ActionResult<Course> GetCourse(int id, int courseId)
        {
            ExamProgram program = dataService.FindById<ExamProgram>(id, new string[] { "Courses" });

            if (program == null)
            {
                return NotFound("Examprogram not found");
            }

            foreach (Course course in program.Courses)
            {
                if (course.Id == courseId)
                {
                    return new OkObjectResult(course);
                }
            }

            return NotFound("Course not found");
        }

        /// <summary>
        /// Add a new Course to an existing Exam Program
        /// </summary>
        /// <param name="id">The Exam Program ID to add a Course to</param>
        /// <param name="courseId">The Course ID</param>
        /// <returns>The newly added Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Course could not be created</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPost("{id}/courses", Name = ExamProgramRoutes.POST_EXAMPROGRAM_COURSES)]
        public ActionResult<Course> PostCourse(int id, [FromBody] IdViewModel courseId)
        {
            ExamProgram examprogram = dataService.FindById<ExamProgram>(id, new string[] { "Courses" });
            Course course = dataService.FindById<Course>(courseId.Id);

            if (course == null)
            {
                return NotFound("Course not found");
            }
            else if (examprogram == null)
            {
                return NotFound("Examprogram not found");
            }

            examprogram.Courses.Add(course);

            if (dataService.Update<ExamProgram>(examprogram) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(course);
        }

        /// <summary>
        /// Removes an existing Course from a Exam Program
        /// </summary>
        /// <param name="id">The Exam Program ID</param>
        /// <param name="courseId">The Course ID to remove</param>
        /// <returns>The removed Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="400">If the specified Course could not be removed</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}/courses/{courseid}", Name = ExamProgramRoutes.DELETE_EXAMPROGRAM_COURSES_COURSE)]
        public ActionResult<Course> DeleteCourse(int id, int courseId)
        {
            ExamProgram examprogram = dataService.FindById<ExamProgram>(id, new string[] { "Courses" });
            Course course = dataService.FindById<Course>(courseId);

            if (course == null)
            {
                return NotFound("Course not found");
            }
            else if (examprogram == null)
            {
                return NotFound("Examprogram not found");
            }

            foreach (Course courseIn in examprogram.Courses)
            {
                if (courseIn.Id == courseId)
                {
                    examprogram.Courses.Remove(courseIn);
                    break;
                }
            }

            if (dataService.Update<ExamProgram>(examprogram) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(examprogram);
        }
    }
}
