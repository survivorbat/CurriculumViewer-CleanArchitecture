using CurriculumViewer.Domain.Models;
using System.Collections.Generic;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
	public class CourseCreateUpdateViewModel : Course
    {
		public CourseCreateUpdateViewModel()
		{
			ModuleIds = new List<int>();
		}

		public List<int> ModuleIds { get; set; }
		public int ExamProgramId { get; set; }
        public int MentorId { get; set; }
    }
}
