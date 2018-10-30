using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed module object.
	/// </summary>
	public class Module
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Module"/> class.
		/// </summary>
		public Module()
		{
			Goals = new HashSet<Goal>();
			Exams = new HashSet<Exam>();
            InCourses = new HashSet<CourseModule>();
		}

		/// <summary>
		/// Gets or sets the ID of the module.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name of the module.
		/// </summary>    
		[Display(Name = "Naam")]
		[Required(ErrorMessage = "Een naam is verplicht.")]
        [DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description of the module.
		/// </summary>
		[Display(Name = "Omschrijving")]
		[Required(ErrorMessage = "Een omschrijving is verplicht.")]
		[MaxLength(4096, ErrorMessage = "De omschrijving overschrijd de maximum karaters van 4096.")]
		[DataType(DataType.MultilineText, ErrorMessage = "Deze tekenreeks is niet valide.")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the Osiris code of the module.
		/// </summary>
		[Display(Name = "Osiris code")]
		[Required(ErrorMessage = "Een Osiris code is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string OsirisCode { get; set; }

		/// <summary>
		/// Gets or sets Teacher
		/// </summary>
		[Display(Name = "Docent")]
		public virtual Teacher Teacher { get; set; }

		/// <summary>
		/// Gets or sets a <see cref="ICollection{T}"/> that represents the goals of the module.
		/// </summary>
		public virtual ICollection<Goal> Goals { get; set; }

		/// <summary>
		/// Gets or sets a <see cref="ICollection{T}"/> that represents the exams of the module.
		/// </summary>
		public virtual ICollection<Exam> Exams { get; set; }

        /// <summary>
        /// Courses this module is part of
        /// </summary>
        public virtual ICollection<CourseModule> InCourses { get; set; }

		/// <summary>
		/// Gets the total amount of European Credits awarded from this module.
		/// </summary>    
		[Display(Name = "EC")]
		public virtual int EC
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
            foreach (Exam exam in Exams)
            {
                count += exam.EC;
            }
            return count;
        }
    }
}
