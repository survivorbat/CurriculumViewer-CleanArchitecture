using CurriculumViewer.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed exam object.
	/// </summary>
	public class Exam
    {
		/// <summary>
		/// Gets or sets the ID of the exam.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the language of the exam.
		/// </summary>
		[Display(Name = "Taal")]
		[Required(ErrorMessage = "Een taal specificeren is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string Language { get; set; }

		/// <summary>
		/// Gets or sets the type of the exam.
		/// </summary>
		[Display(Name = "Type toetsonderdeel")]
		[Required(ErrorMessage = "Het type van het toetsonderdeel specificeren is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string ExamType { get; set; }

		/// <summary>
		/// Gets or sets the EC (European Credit) of the exam.
		/// </summary>
		[Display(Name = "EC")]
		[Required(ErrorMessage = "De verdiende EC specificeren is verplicht.")]
		[Range(1, 60, ErrorMessage = "De verdiende EC van een toetsonderdeel kan alleen tussen 1 en 60 liggen.")]
        public int EC { get; set; }

		/// <summary>
		/// Gets or sets the grade type of the exam.
		/// </summary>
		[Display(Name = "Type punt")]
		[Required(ErrorMessage = "Het type van het punt specificeren is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string GradeType { get; set; }

		/// <summary>
		/// Gets or sets the weight of the exam.
		/// </summary>
		[Display(Name = "Gewicht")]
		[Required(ErrorMessage = "Het gewicht specificeren is verplicht.")]
		[Range(0, 100, ErrorMessage = "Het gewicht van een toetsonderdeel kan alleen tussen 0 en 100 liggen.")]
        public double Weight { get; set; }

		/// <summary>
		/// Gets or sets the passing grade of the exam.
		/// </summary>
		[Display(Name = "Voldoende")]
		[Required(ErrorMessage = "Een voldoende specificeren is verplicht.")]
		[Range(0, 10, ErrorMessage = "Een voldoende van een toetsonderdeel kan alleen tussen 1 en 10 liggen.")]
        public double PassingGrade { get; set; }

		/// <summary>
		/// Gets or sets whenever the exam is compensatable.
		/// </summary>       
		[Display(Name = "Compenseerbaar")]
		[Required(ErrorMessage = "Aangeven of dat een toetsonderdeel compenseerbaar is, is verplicht.")]
        public bool Compensatable { get; set; }

		/// <summary>
		/// Gets or sets the teacher of the exam.
		/// </summary>
		[Display(Name = "Verantwoordelijke docent")]
		[Required(ErrorMessage = "Een verantwoordelijke docent aangeven is verplicht.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public Teacher ResponsibleTeacher { get; set; }

		/// <summary>
		/// Gets or sets the duration of the exam.
		/// </summary>
		[Display(Name = "Duur")]
		[Required(ErrorMessage = "De duur van een toetsonderdeel is verplicht.")]
		[DataType(DataType.Time, ErrorMessage = "De gespecificeerde duur van de toetsonderdeel is niet valide.")]
		public TimeSpan Duration { get; set; }

		/// <summary>
		/// Gets or sets when the first attempt of the exam occurs.
		/// </summary>
		[Display(Name = "Kans 1")]
		[Required(ErrorMessage = "Specificeren wanneer kans 1 begint is verplicht.")]
		[DataType(DataType.Time, ErrorMessage = "De gespecificeerde datum van kans 1 is niet valide.")]
		public DateTime AttemptOne { get; set; }

		/// <summary>
		/// Gets or sets when the second attempt of the exam occurs.
		/// </summary>
		[Display(Name = "Kans 2")]
		[Required(ErrorMessage = "Specificeren wanneer kans 2 begint is verplicht.")]
		[DataType(DataType.Time, ErrorMessage = "De gespecificeerde datum van kans 2 is niet valide.")]
		public DateTime AttemptTwo { get; set; }
        
        /// <summary>
        /// Module
        /// </summary>
        public virtual Module Module { get; set; }

		/// <summary>
		/// Name of the exam
		/// 
		/// NOTE: IF YOU ARE USING THIS METHOD ANYWHERE BE SURE TO INCLUDE TEACHER AND MODULE
		/// </summary>
		[Display(Name = "Naam")]
		public virtual string Name
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                String responsibleTeacher = "";
                if (ResponsibleTeacher != null)
                    responsibleTeacher = ResponsibleTeacher.FullName;
                String module = "";
                if (Module != null)
                    module = Module.Name;

                stringBuilder.Append($"{module} - {responsibleTeacher} ({EC} EC)");

                return stringBuilder.ToString();
            }
        }
    }
}
