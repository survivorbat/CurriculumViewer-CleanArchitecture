namespace CurriculumViewer.Domain.Models
{
	public class TeacherModule
    {
        public virtual Teacher Teacher { get; set; }

        public int TeacherId { get; set; }


        /// <summary>
        /// Gets or sets a <see cref="Module"/> object as course-module.
        /// </summary>
        public virtual Module Module { get; set; }

        /// <summary>
        /// Gets or sets the module ID of the course-module.
        /// </summary>
        public int ModuleId { get; set; }
    }
}
