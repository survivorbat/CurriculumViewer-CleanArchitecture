using CurriculumViewer.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
	public class SideBarViewComponent : ViewComponent
    {
        private IGenericService<ExamProgram> genericService;

        public SideBarViewComponent(IGenericService<ExamProgram> genericService)
        {
            this.genericService = genericService;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            SideBarViewModel sideBarViewModel = new SideBarViewModel();
            sideBarViewModel.examPrograms =
                genericService.FindAll(new string[] {"Courses"}).ToList();
            return Task.FromResult<IViewComponentResult>(View(sideBarViewModel));
		}
	}
}
