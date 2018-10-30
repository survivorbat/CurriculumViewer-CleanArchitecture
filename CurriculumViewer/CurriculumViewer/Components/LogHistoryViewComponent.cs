using CurriculumViewer.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
	public class LogHistoryViewComponent : ViewComponent
    {
        private IGenericService<LogItem> genericService;

        public LogHistoryViewComponent(IGenericService<LogItem> genericService)
        {
            this.genericService = genericService;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<LogItem> data = genericService.FindAll().ToList();
            return Task.FromResult<IViewComponentResult>(View(data));
		}
	}
}
