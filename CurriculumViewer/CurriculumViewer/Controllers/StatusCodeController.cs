using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for status codes.
    /// </summary>
    [Authorize]
    public class StatusCodeController : Controller
	{
		private readonly ILogger<HomeController> logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="StatusCodeController"/> class.
		/// </summary>
		/// <param name="logger">When overridden in a derived form, provides functionality for loggers that handle events raised by the url that the request came through.</param>
		public StatusCodeController(ILogger<HomeController> logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		[HttpGet("/StatusCode/{statusCode}")]
		public IActionResult Index(int statusCode)
		{
			IStatusCodeReExecuteFeature reExecute = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
			logger.LogInformation($"Unexpected Status Code: {statusCode}, OriginalPath: {reExecute.OriginalPath}");
			return View(statusCode);
		}
	}
}