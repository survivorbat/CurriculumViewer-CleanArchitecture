using CurriculumViewer.Domain.Models;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed course-module object.
	/// </summary>
	public class CourseModule
    {
		/// <summary>
		/// Gets or sets a <see cref="Course"/> object as course-module.
		/// </summary>
		public virtual Course Course { get; set; }

		/// <summary>
		/// Gets or sets the course ID of the course-module.
		/// </summary>
		public int CourseId { get; set; }

		/// <summary>
		/// Gets or sets a <see cref="Module"/> object of the course.
		/// </summary>
		public virtual Module Module { get; set; }

		/// <summary>
		/// Gets or sets the module ID of the course.
		/// </summary>
		public int ModuleId { get; set; }
    }
}
