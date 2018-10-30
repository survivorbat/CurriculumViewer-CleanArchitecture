using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CurriculumViewer.Domain.Models;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed course object.
	/// </summary>
	public class Course
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Course"/> class.
		/// </summary>
		public Course()
		{
			Modules = new HashSet<CourseModule>();
		}

		/// <summary>
		/// Gets or sets the ID of the course.
		/// </summary>
		[Key]
		public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the course.
        /// </summary>
		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Een naam is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the course.
		/// </summary>
		[Display(Name = "Omschrijving")]
		[Required(ErrorMessage = "Een omschrijving is verplicht.")]
		[MaxLength(4096, ErrorMessage = "De omschrijving overschrijd de maximum karaters van 4096.")]
        [DataType(DataType.MultilineText, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string Description { get; set; }

		/// <summary>
		/// Gets or sets the mentor of the course.
		/// </summary>
		[Display(Name = "Docent")]
		public virtual Teacher Mentor { get; set; }

        /// <summary>
		/// Gets or sets a <see cref="ICollection{T}"/> that represents the modules at the course.
		/// </summary>
		public virtual ICollection<CourseModule> Modules { get; set; }
        
        public int StudyYear { get; set; }

        /// <summary>
        /// Examprogram
        /// </summary>
        public virtual ExamProgram ExamProgram { get; set; }

		/// <summary>
		/// Gets the total amount of European Credits awarded from this module.
		/// </summary>    
		[Display(Name = "EC")]
		public int EC
        {
            get { return CalculateECs(); }
        }

		/// <summary>
		/// Calculates the total amount of European Credits awarded when completing this module.
		/// </summary>
		/// <returns>The total amount of European Credits awarded.</returns>
		private int CalculateECs()
        {
            int count = 0;

            foreach (CourseModule module in Modules)
            {
                count += module.Module.EC;
            }

            return count;
        }
    }
}
