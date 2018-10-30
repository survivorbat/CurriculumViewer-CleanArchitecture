using CurriculumViewer.WebUI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class HomeControllerTests
	{
		[Fact]
		public void StatusCode404ShouldWorkCorrectly()
		{
			HomeController controller = new HomeController()
			{
				ControllerContext = new ControllerContext()
				{
					HttpContext = new DefaultHttpContext() {  }
				}
			};

			controller.ControllerContext.HttpContext.Response.StatusCode = 404;
			controller.Response.StatusCode = 404;

			// Act
			IActionResult viewResult = controller.Index();

			// Assert
			Assert.Equal(404, controller.Response.StatusCode);
		}
	}
}
