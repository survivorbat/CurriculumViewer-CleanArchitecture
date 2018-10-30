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
    [Route("api/v1/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        /// <summary>
        /// Service to get the data from
        /// </summary>
        private IGenericServiceV2 dataService;

        private IManyToManyMapperService<Course, CourseModule, Module> mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseController"/> class.
        /// </summary>
        /// <param name="dataService">Service that provides data operations.</param>
        /// <param name="mapper">Map entities to one or another.</param>
        public CourseController(IGenericServiceV2 dataService, IManyToManyMapperService<Course, CourseModule, Module> mapper)
        {
            this.dataService = dataService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns>All Courses</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Course</response>  
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [HttpGet(Name = CourseRoutes.GET_COURSES)]
        public ActionResult<List<Course>> Get()
        {
            List<Course> data = dataService.FindAll<Course>(STDIncludes.Courses).ToList();
            return new OkObjectResult(data);
        }

        /// <summary>
        /// Get a Course by ID
        /// </summary>
        /// <param name="id">The Course ID to retrieve</param>
        /// <returns>The speficied Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Course</response>
        /// <response code="404">If the specified Course could not be found</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name = CourseRoutes.GET_COURSE)]
        public ActionResult<Course> Get(int id)
        {
            Course result = dataService.FindById<Course>(id, STDIncludes.Courses);

            if (result == null)
            {
                return NotFound("Course not found");
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Creates a new Course
        /// </summary>
        /// <param name="value">The created Course object</param>
        /// <returns>The newly created Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="200">Returns the speficied Course</response>
        /// <response code="400">If the specified Course could not be created</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [HttpPost(Name = CourseRoutes.POST_COURSE)]
        public ActionResult<Course> Post([FromBody] CourseViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(value.Teacher);

            if (teacher == null)
            {
                return NotFound("Teacher does not exist");
            }

            Course course = new Course
            {
                Description = value.Description,
                Mentor = teacher,
                Name = value.Name,
                StudyYear = value.StudyYear
            };

            if (dataService.Insert<Course>(course) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(course);
        }

        /// <summary>
        /// Updates an existing Course
        /// </summary>
        /// <param name="id">The Course ID to update</param>
        /// <param name="value">The updated Course object</param>
        /// <returns>The updated Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="400">If the specified Course could not be updated</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpPut("{id}", Name = CourseRoutes.PUT_COURSE)]
        public ActionResult<Course> Put(int id, [FromBody] CourseViewModel value)
        {
            Teacher teacher = dataService.FindById<Teacher>(value.Teacher);
            Course course = dataService.FindById<Course>(id);

            if (teacher == null)
            {
                return NotFound("Teacher does not exist");
            }
            else if (course == null)
            {
                return NotFound("Course does not exist");
            }

            course.Description = value.Description;
            course.Mentor = teacher;
            course.Name = value.Name;
            course.StudyYear = value.StudyYear;

            if (dataService.Update<Course>(course) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(value);
        }

        /// <summary>
        /// Deletes an existing Course
        /// </summary>
        /// <param name="id">The Course ID to delete</param>
        /// <returns>The deleted Course</returns>
        /// <response code="500">If an internal error occured</response>
        /// <response code="404">If the specified Course could not be found</response>
        /// <response code="200">Returns the speficied Course</response>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpDelete("{id}", Name = CourseRoutes.DELETE_COURSE)]
        public ActionResult<Course> Delete(int id)
        {
            Course result = dataService.FindById<Course>(id);

            if (result == null)
            {
                return NotFound("Course not found");
            }

            if (dataService.Delete<Course>(result) != 1)
            {
                return StatusCode(500);
            }

            return new OkObjectResult(result);
        }

        /// <summary>
        /// Modules from course
        /// </summary>
        /// <param name="id">Id of course</param>
        /// <returns>Module</returns>
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [HttpGet("{id}/modules", Name = CourseRoutes.GET_COURSE_MODULES)]
        public ActionResult<List<Module>> GetCourses(int id)
        {
            Course data = dataService.FindById<Course>(id, new string[] { "Modules.Module" });

            if (data == null)
            {
                return NotFound("Course not found");
            }

            return new OkObjectResult(data.Modules.Select(e => e.Module));
        }

        /// <summary>
        /// Add a module to course
        /// </summary>
        /// <param name="id">Course id</param>
        /// <param name="moduleId">Module id</param>
        /// <returns>New course module</returns>
        [HttpPost("{id}/modules", Name = CourseRoutes.POST_COURSE_MODULES)]
        public ActionResult<List<Course>> PostModules(int id, int moduleId)
        {
            Course course = dataService.FindById<Course>(id, new string[] { "Modules.Module" });
            Module module = dataService.FindById<Module>(moduleId);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            course.Modules.Add(mapper.GetMappedEntities(course, new Module[] { module }).First());

            if (dataService.Update<Course>(course) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }

        /// <summary>
        /// Get module
        /// </summary>
        /// <param name="id">Id of course</param>
        /// <param name="moduleId">Module to add</param>
        /// <returns></returns>
        [HttpGet("{id}/modules/{moduleid}", Name = CourseRoutes.GET_COURSE_MODULES_MODULE)]
        public ActionResult<Module> GetModule(int id, int moduleId)
        {
            Course data = dataService.FindById<Course>(id, new string[] { "Modules.Module" });

            if (data == null)
            {
                return NotFound("Course not found");
            }

            foreach (CourseModule module in data.Modules)
            {
                if (module.ModuleId == moduleId)
                {
                    return new OkObjectResult(module.Module);
                }
            }

            return NotFound("Module not found");
        }

        /// <summary>
        /// Remove module from course
        /// </summary>
        /// <param name="id">Id of course</param>
        /// <param name="moduleId">Module id</param>
        /// <returns></returns>
        [HttpDelete("{id}/modules/{moduleid}", Name = CourseRoutes.DELETE_COURSE_MODULES_MODULE)]
        public ActionResult<Module> DeleteModule(int id, int moduleId)
        {
            Course course = dataService.FindById<Course>(id, new string[] { "Modules.Module" });
            Module module = dataService.FindById<Module>(moduleId);

            if (course == null)
            {
                return NotFound("Course not found");
            }

            foreach (CourseModule moduleCourse in course.Modules)
            {
                if (moduleCourse.ModuleId == moduleId)
                {
                    course.Modules.Remove(moduleCourse);
                    break;
                }
            }

            if (dataService.Update<Course>(course) != 1)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(module);
        }
    }
}
