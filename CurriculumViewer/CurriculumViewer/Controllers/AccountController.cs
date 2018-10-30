using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Controllers
{
    /// <summary>
    /// A class for an MVC controller with view support for accounts.
    /// </summary>
    [Authorize]
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> userManager;
		private SignInManager<ApplicationUser> signInManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountController"/> class.
		/// </summary>
		/// <param name="userManager">Provides the APIs for managing students in a persistence store.</param>
		/// <param name="signInManager">Provides the APIs for student sign in.</param>
		/// <param name="studentRepository">Provides specific data operations for the <see cref="Student"/> model.</param>
		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Index"/> view to the response.
		/// </summary>
		/// <returns>A view of the <see cref="Index"/> action method.</returns>
		[Authorize]
		public IActionResult Index()
		{
			return View();
		}

		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Login(string)"/> view to the response.
		/// </summary>
		/// <param name="returnUrl">The URL of the view the student came from post-login.</param>
		/// <returns>A view of the <see cref="Login(string)"/> action method.</returns>
		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}
			else if (User?.Identity?.IsAuthenticated == true)
			{
				actionResult = Redirect("/Home");
			}
			else
			{
				actionResult = View(new LoginViewModel
				{
					ReturnUrl = returnUrl
				});
			}

			return actionResult;
		}

		/// <summary>
		/// Represents an <see cref="Task{TResult}"/> that renders the the <see cref="Login(LoginViewModel)"/> view to the response.
		/// </summary>
		/// <param name="loginViewModel">Represents a part of the login view.</param>
		/// <returns>A view of the <see cref="Login(LoginViewModel)"/> action method.</returns>
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
            IActionResult actionResult = View(loginViewModel);

            if (User?.Identity?.IsAuthenticated == true)
            {
                actionResult = Redirect("/Home");
            }
            else if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginViewModel.Username);

                if (signInManager?.SignOutAsync().IsCompletedSuccessfully == true && (await signInManager.PasswordSignInAsync(user ?? new ApplicationUser(), loginViewModel.Password, false, false)).Succeeded)
                {
                    actionResult = Redirect(loginViewModel?.ReturnUrl ?? "/Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid name or password");
                }
            }

            return actionResult;
        }

		/// <summary>
		/// Represents an <see cref="Task{TResult}"/> that renders the the <see cref="Logout(string)"/> view asynchronous to the response.
		/// </summary>
		/// <param name="returnUrl">The URL of the view the student came from post-login.</param>
		/// <returns>A view of the <see cref="Logout(string)"/> action method.</returns>
		public async Task<IActionResult> Logout(string returnUrl = "/")
		{
			await signInManager.SignOutAsync();
			return Redirect(returnUrl);
		}

		/// <summary>
		/// Represents an <see cref="IActionResult"/> that renders the the <see cref="Register(string)"/> view to the response.
		/// </summary>
		/// <param name="returnUrl">The URL of the view the student came from post-login.</param>
		/// <returns>A view of the <see cref="Register(string)"/> action method.</returns>
		[HttpGet]
		public IActionResult Register(string returnUrl = null)
		{
			IActionResult actionResult = View();

			if (!ModelState.IsValid)
			{
				actionResult = View("Error");
			}

			ViewData["ReturnUrl"] = returnUrl;
			return actionResult;
		}

		/// <summary>
		/// Represents an <see cref="Task{TResult}"/> that renders the the <see cref="Register(RegisterViewModel, string)"/> view asynchronous to the response.
		/// </summary>
		/// <param name="registerViewModel">Represents a part of the register view.</param>
		/// <param name="returnUrl">The URL of the view the student came from post-login.</param>
		/// <returns>A view of the <see cref="Register(RegisterViewModel, string)"/> action method.</returns>
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
		{
			IActionResult actionResult = View(registerViewModel);

			ViewData["ReturnUrl"] = returnUrl;

			if (ModelState.IsValid)
			{
				ApplicationUser user = new ApplicationUser
				{
					UserName = registerViewModel.Username,
					Email = registerViewModel.Email,
					FirstName = registerViewModel.FirstName,
					MiddleName = registerViewModel.MiddleName,
					LastName = registerViewModel.LastName
				};

				IdentityResult result = await userManager.CreateAsync(user, registerViewModel.Password);

				if (result.Succeeded)
				{
					actionResult = Redirect("/");
				}
				else
				{
					foreach (IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}

			return actionResult;
		}
	}
}