using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
    public class LearningLine
    {
        /// <summary>
        /// Initialize lists
        /// </summary>
        public LearningLine()
        {
            Goals = new HashSet<LearningLineGoal>();
        }

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the learningline
		/// </summary>
        [Required (ErrorMessage = "Naam mag niet leeg zijn.")]
		[Display(Name = "Naam")]
		public string Name { get; set; }

        /// <summary>
        /// Leerdoelen
        /// </summary>
        public virtual ICollection<LearningLineGoal> Goals { get; set; }
    }
}
