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
    /// <summary>
    /// Teachers
    /// </summary>
    [Route("api/v1/teachers")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        public TeacherController(IGenericServiceV2 dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// Get all Teachers
        /// </summary>
        /// <returns>All Teachers</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Teacher</response>  
        [HttpGet(Name = TeacherRoutes.GET_TEACHERS)]
        public ActionResult<IEnumerable<Teacher>> Get()
        {
            IEnumerable<Teacher> data = dataService.FindAll<Teacher>(STDIncludes.Teachers).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Teacher by ID
        /// </summary>
        /// <param name="id">The Teacher ID to retrieve</param>
        /// <returns>The speficied Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Teacher could not be found</response>
        /// <response code="200">Returns the speficied Teacher</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [HttpGet("{id}", Name = TeacherRoutes.GET_TEACHER)]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher result = dataService.FindById<Teacher>(id, STDIncludes.Teachers);

            if (result == null)
            {
                return NotFound("Teacher not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Teacher
        /// </summary>
        /// <param name="value">The created Teacher object</param>
        /// <returns>The newly created Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="400">If the specified Teacher could not be created</response>
        /// <response code="200">Returns the speficied Teacher</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost(Name = TeacherRoutes.POST_TEACHER)]
        public ActionResult<Teacher> Post([FromBody] TeacherViewModel value)
        {
            Teacher teacher = new Teacher()
            {
                FirstName = value.FirstName,
                MiddleName = value.MiddleName,
                LastName = value.LastName
            };

            if (dataService.Insert<Teacher>(teacher) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(teacher);
        }

        /// <summary>
        /// Updates an existing Teacher
        /// </summary>
        /// <param name="id">The Teacher ID to update</param>
        /// <param name="value">The updated Teacher object</param>
        /// <returns>The updated Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Teacher could not be found</response>
        /// <response code="400">If the specified Teacher could not be updated</response>
        /// <response code="200">Returns the speficied Teacher</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpPut("{id}", Name = TeacherRoutes.PUT_TEACHER)]
        public ActionResult<Teacher> Put(int id, [FromBody] TeacherViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(id);

            if (teacher == null)
            {
                return BadRequest("Teacher not found");
            }

            teacher.FirstName = value.FirstName;
            teacher.MiddleName = value.MiddleName;
            teacher.LastName = value.LastName;

            if (dataService.Update<Teacher>(teacher) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(teacher);
        }

        /// <summary>
        /// Deletes an existing Teacher
        /// </summary>
        /// <param name="id">The Teacher ID to delete</param>
        /// <returns>The deleted Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Teacher could not be found</response>
        /// <response code="200">Returns the speficied Teacher</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}", Name = TeacherRoutes.DELETE_TEACHER)]
        public ActionResult<Teacher> Delete(int id)
        {
            Teacher result = dataService.FindById<Teacher>(id);

            if (result == null)
            {
                return NotFound("Teacher not found");
            }

            if (dataService.Delete(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Get all Modules linked to an Teacher
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <returns>All Modules of the specified Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Modules</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/modules", Name = TeacherRoutes.GET_TEACHER_MODULES)]
        public ActionResult<ICollection<Module>> GetModules(int id)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForModules.Module" });

            if (result == null)
            {
                return NotFound("Teacher not found");
            }

            return new OkObjectResult(result.ResponsibleForModules);
        }

        /// <summary>
        /// Get a Module linked to an Teacher by ID
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <param name="moduleId">The Module ID to retrieve</param>
        /// <returns>The speficied Module</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Module could not be found</response>
        /// <response code="200">Returns the speficied Module</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/modules/{moduleid}", Name = TeacherRoutes.GET_TEACHER_MODULES_MODULE)]
        public ActionResult<Module> GetModule(int id, int moduleId)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForModules.Module" });

            if (result == null)
            {
                return NotFound("Teacher not found");
            }

            foreach (TeacherModule module in result.ResponsibleForModules)
            {
                if (module.ModuleId == moduleId)
                {
                    return new OkObjectResult(module.Module);
                }
            }

            return NotFound("Module not found");
        }

        /// <summary>
        /// Get all Courses linked to an Teacher
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <returns>All Courses of the specified Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Courses</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/courses", Name = TeacherRoutes.GET_TEACHER_COURSES)]
        public ActionResult<ICollection<Course>> GetCourses(int id)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForCourses" });

            if (result == null)
            {
                return NotFound("Teacher not found");
            }

            return new OkObjectResult(result.ResponsibleForCourses);
        }

        /// <summary>
        /// Get a Course linked to an Teacher by ID
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <param name="courseId">The Course ID to retrieve</param>
        /// <returns>The speficied Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/courses/{courseid}", Name = TeacherRoutes.GET_TEACHER_COURSES_COURSE)]
        public ActionResult<Course> GetCourse(int id, int courseId)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForCourses" });

            if (result == null)
            {
                return NotFound("Course not found");
            }

            foreach (Course course in result.ResponsibleForCourses)
            {
                if (course.Id == courseId)
                {
                    return new OkObjectResult(course);
                }
            }

            return NotFound("Course not found");
        }

        /// <summary>
        /// Get all Exams linked to an Teacher
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <returns>All Exams of the specified Teacher</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Exams</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/exams", Name = TeacherRoutes.GET_TEACHER_EXAMS)]
        public ActionResult<ICollection<Exam>> GetExams(int id)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForExams" });

            if (result == null)
            {
                return NotFound("Learningline not found");
            }

            return new OkObjectResult(result.ResponsibleForExams);
        }

        /// <summary>
        /// Get a Exam linked to an Teacher by ID
        /// </summary>
        /// <param name="id">The Teacher ID</param>
        /// <param name="examId">The Exam ID to retrieve</param>
        /// <returns>The speficied Exam</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Exam could not be found</response>
        /// <response code="200">Returns the speficied Exam</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/exams/{examid}", Name = TeacherRoutes.GET_TEACHER_EXAMS_EXAM)]
        public ActionResult<Exam> GetExam(int id, int examId)
        {
            Teacher result = dataService.FindById<Teacher>(id, new string[] { "ResponsibleForExams" });

            if (result == null)
            {
                return NotFound("Learningline not found");
            }

            foreach (Exam exam in result.ResponsibleForExams)
            {
                if (exam.Id == examId)
                {
                    return new OkObjectResult(exam);
                }
            }

            return NotFound("Exam not found");
        }
    }
}
