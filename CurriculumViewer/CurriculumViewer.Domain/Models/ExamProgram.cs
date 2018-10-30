using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
    public class ExamProgram
    {
        public ExamProgram()
        {
            Courses = new HashSet<Course>();
        }

        [Key]
        public int Id { get; set; }

		[Display(Name = "Start datum")]
		[Required(ErrorMessage = "Specificeren wanneer de start datum begint is verplicht.")]
		[DataType(DataType.Time, ErrorMessage = "De gespecificeerde start datum is niet valide.")]
		public DateTime StartDate { get; set; }

		[Display(Name = "Eind datum")]
		[Required(ErrorMessage = "Specificeren wanneer de eind datum eindigt is verplicht.")]
		[DataType(DataType.Time, ErrorMessage = "De gespecificeerde eind datum is niet valide.")]
		public DateTime EndDate { get; set; }

        public ICollection<Course> Courses { get; set; }

		/// <summary>
		/// Gets the name of the examprogram
		/// </summary>
		/// <returns>The full name of the examprogram.</returns>
		[Display(Name = "Naam")]
		public virtual string Name
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"{StartDate.Year} - {EndDate.Year}");
                return stringBuilder.ToString();
            }
        }
    }
}
