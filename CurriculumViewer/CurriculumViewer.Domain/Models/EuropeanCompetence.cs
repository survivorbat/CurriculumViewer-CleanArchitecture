using System.ComponentModel.DataAnnotations;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed European Competence object.
	/// </summary>
	public class EuropeanCompetence
    {
		/// <summary>
		/// Gets or sets the ID of the European Competence.
		/// </summary>
		[Key]
		public int Id { get; set; }
    }
}
