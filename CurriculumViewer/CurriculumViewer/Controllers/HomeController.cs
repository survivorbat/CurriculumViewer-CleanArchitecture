using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for home.
    /// </summary
    [Authorize]
    public class HomeController : Controller
	{
		/// <summary>
		/// Represents an <see cref="ActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		public IActionResult Index()
		{
			return View();
		}
	}
}
