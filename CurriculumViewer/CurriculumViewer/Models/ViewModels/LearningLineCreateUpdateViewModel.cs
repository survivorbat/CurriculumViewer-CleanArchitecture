using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public class LearningLineCreateUpdateViewModel : LearningLine
    {
		public LearningLineCreateUpdateViewModel()
		{
			GoalsIds = new List<int>();
		}

		[Required(ErrorMessage = "Minimaal één leerdoel selecteren.")]
        [MinLength(1)]
        public List<int> GoalsIds { get; set; } = new List<int>();
    }
}
