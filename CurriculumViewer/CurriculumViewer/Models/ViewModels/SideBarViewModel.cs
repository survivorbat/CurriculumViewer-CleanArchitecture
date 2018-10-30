using CurriculumViewer.Abstract.Services;
using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public class SideBarViewModel
    {
        public List<ExamProgram> examPrograms { get; set; }
    }
}
