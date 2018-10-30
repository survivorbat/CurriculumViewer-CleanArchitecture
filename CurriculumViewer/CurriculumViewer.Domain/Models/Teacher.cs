using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
	public class Teacher
    {
        public Teacher()
        {
            ResponsibleForExams = new HashSet<Exam>();
            ResponsibleForModules = new HashSet<TeacherModule>();
            ResponsibleForCourses = new HashSet<Course>();
        }

		/// <summary>
		/// Gets or sets the ID of the teacher.
		/// </summary>
		[Key]
        public int Id { get; set; }

		/// <summary>
		/// Gets or sets the first name of the teacher.
		/// </summary>
		[Display(Name = "Voornaam")]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the middle name of the teacher.
		/// </summary>
		[Display(Name = "Tussenvoegsel")]
		public string MiddleName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the teacher.
		/// </summary>
		[Display(Name = "Achternaam")]
		public string LastName { get; set; }

        /// <summary>
        /// Responsible for modules
        /// </summary>
        public virtual ICollection<TeacherModule> ResponsibleForModules { get; set; }

        /// <summary>
        /// Responsible for courses
        /// </summary>
        public virtual ICollection<Course> ResponsibleForCourses { get; set; }

        /// <summary>
        /// Responsible for exams
        /// </summary>
        public virtual ICollection<Exam> ResponsibleForExams { get; set; }
		
        /// <summary>
		/// Gets the full name of the teacher.
		/// </summary>
		/// <returns>The full name of the teacher.</returns>
		public virtual string FullName
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append($"{FirstName}");

				if (!string.IsNullOrWhiteSpace(MiddleName))
				{
					stringBuilder.Append($" {MiddleName}");
				}

				stringBuilder.Append($" {LastName}");
				return stringBuilder.ToString();
			}
		}
	}
}
