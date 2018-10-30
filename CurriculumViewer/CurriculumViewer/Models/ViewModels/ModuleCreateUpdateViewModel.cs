using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public class ModuleCreateUpdateViewModel : Module
    {
		public ModuleCreateUpdateViewModel()
		{
			GoalsIds = new List<int>();
			ExamsIds = new List<int>();
		}

		public List<int> GoalsIds { get; set; }
        public List<int> ExamsIds { get; set; }
        public int TeacherId { get; set; }
    }
}
