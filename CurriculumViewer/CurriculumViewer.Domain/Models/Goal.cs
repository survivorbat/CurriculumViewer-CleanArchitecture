using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CurriculumViewer.Domain.Models
{
	/// <summary>
	/// Represents a strongly typed goal object.
	/// </summary>
	public class Goal
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Goal()
        {
            InLearningLines = new HashSet<LearningLineGoal>();
        }

		/// <summary>
		/// Gets or sets the ID of the goal.
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the description of the goal.
		/// </summary>
		[Display(Name = "Omschrijving")]
		[Required(ErrorMessage = "Een omschrijving is verplicht.")]
		[MaxLength(4096, ErrorMessage = "De omschrijving overschrijd de maximum karaters van 4096.")]
		[DataType(DataType.MultilineText, ErrorMessage = "Deze tekenreeks is niet valide.")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the bloom of the goal.
		/// </summary>
		[Display(Name = "Bloom")]
		[Required(ErrorMessage = "Een bloom is verplicht.")]
		[MaxLength(100, ErrorMessage = "De tekenreeks kan niet groter zijn dan 100.")]
		[DataType(DataType.Text, ErrorMessage = "Deze tekenreeks is niet valide.")]
        public string Bloom { get; set; }

        /// <summary>
        /// Part of modules
        /// </summary>
        public virtual Module Module { get; set; } 

        /// <summary>
        /// Part of learninglines
        /// </summary>
        public virtual ICollection<LearningLineGoal> InLearningLines { get; set; }
        
        /*
         The properties under this comment should stay disabled until their models exist.
         After that they can be implemented.
        */
        //public ICollection<GoalsCompetency> Goals { get; set; } 
        //public ICollection<CompetencyCoverage> Coverages { get set; }
    }
}
