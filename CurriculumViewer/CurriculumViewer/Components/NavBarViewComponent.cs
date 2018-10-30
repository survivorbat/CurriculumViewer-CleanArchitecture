using CurriculumViewer.Abstract.Services;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
	public class NavBarViewComponent : ViewComponent
    {
        private ApplicationUser user;

        public NavBarViewComponent(IGenericService<ApplicationUser> applicationUserService)
		{
			try
			{
                user = applicationUserService.FindById(User.Identity.Name);
            }
            catch (NullReferenceException ex)
            {
				Console.WriteLine(ex.Message);
            }
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            NavBarViewModel navBarViewModel = new NavBarViewModel()
			{
                applicationUser = user,
                currentRoute = "/"
            };

			return Task.FromResult<IViewComponentResult>(View(navBarViewModel));
		}
    }
}
