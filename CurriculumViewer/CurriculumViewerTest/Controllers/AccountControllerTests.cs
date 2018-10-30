using CurriculumViewer.Domain.Models;
using CurriculumViewer.WebUI.Controllers;
using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CurriculumViewerTests.WebUI.Controllers
{
	public class AccountControllerTests
	{
		[Theory]
		[InlineData("Ginni", "1")]
		public async Task ShouldReturnInvalidLogin(string username, string password)
		{
			// Arrange
			Mock<IUserStore<ApplicationUser>> userStore = new Mock<IUserStore<ApplicationUser>>();
			userStore.As<IUserPasswordStore<ApplicationUser>>().Setup(x => x.FindByNameAsync(username, CancellationToken.None)).ReturnsAsync((ApplicationUser)null);

			Mock<FakeUserManager> userManager = new Mock<FakeUserManager>();
			userManager.Setup(x => x.Users).Returns((IQueryable<ApplicationUser>)null);
			userManager.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
			userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
			userManager.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);

			AccountController controller = new AccountController(userManager.Object, null);

			LoginViewModel viewModel = new LoginViewModel()
			{
				Username = username,
				Password = password
			};

			// Act
			ViewResult viewResult = (await controller.Login(viewModel)) as ViewResult;

			// Assert
			Assert.False(viewResult.ViewData.ModelState.IsValid);
		}

		[Theory]
		[InlineData("Ginni", "1")]
		public async Task ShouldReturnValidLogin(string username, string password)
		{
			// Arrange
			RegisterViewModel registerViewModel = new RegisterViewModel()
			{
				Username = username,
				Password = password
			};

			ApplicationUser user = new ApplicationUser
			{
				UserName = registerViewModel.Username,
				Email = registerViewModel.Email,
				FirstName = registerViewModel.FirstName,
				MiddleName = registerViewModel.MiddleName,
				LastName = registerViewModel.LastName
			};

			IQueryable<ApplicationUser> users = new List<ApplicationUser> { user }.AsQueryable();

			Mock<IUserStore<ApplicationUser>> userStore = new Mock<IUserStore<ApplicationUser>>();
			userStore.As<IUserPasswordStore<ApplicationUser>>().Setup(x => x.FindByNameAsync(username, CancellationToken.None)).ReturnsAsync(user);

			Mock<FakeUserManager> userManager = new Mock<FakeUserManager>();
			userManager.Setup(x => x.Users).Returns(users);
			userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

			Mock<FakeSignInManager> signInManager = new Mock<FakeSignInManager>();
			signInManager.Setup(x => x.PasswordSignInAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>())).ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

			AccountController controller = new AccountController(userManager.Object, signInManager.Object);

			LoginViewModel loginViewModel = new LoginViewModel()
			{
				Username = user.UserName,
				Password = password
			};

			// Act
			RedirectResult redirectResult = (await controller.Login(loginViewModel)) as RedirectResult;

			// Assert
			Assert.Equal("/", redirectResult?.Url);
		}

		[Theory]
		[InlineData("Ginni", "12345678")]
		public async Task ShouldRegisterWithMinimumPasswordLengthCorrectly(string username, string password)
		{
			// Arrange
			RegisterViewModel registerViewModel = new RegisterViewModel()
			{
				Username = username,
				Password = password
			};

			ApplicationUser user = new ApplicationUser
			{
				UserName = registerViewModel.Username,
				Email = registerViewModel.Email,
				FirstName = registerViewModel.FirstName,
				MiddleName = registerViewModel.MiddleName,
				LastName = registerViewModel.LastName,
			};

			IQueryable<ApplicationUser> users = new List<ApplicationUser> { user }.AsQueryable();

			Mock<IUserStore<ApplicationUser>> userStore = new Mock<IUserStore<ApplicationUser>>();
			userStore.As<IUserPasswordStore<ApplicationUser>>().Setup(x => x.FindByNameAsync(username, CancellationToken.None)).ReturnsAsync(user);

			Mock<FakeUserManager> userManager = new Mock<FakeUserManager>();
			userManager.Setup(x => x.Users).Returns(users);

			if (password.Length >= 8)
			{
				userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
			}
			else
			{
				IdentityError[] erorrs = { new IdentityError() { Description = "Password must be 8 characters long and cannot be longer than 128 characters" } };
				userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(erorrs));
			}

			AccountController controller = new AccountController(userManager.Object, null);

			// Act
			RedirectResult redirectResult = (await controller.Register(registerViewModel)) as RedirectResult;

			// Assert
			Assert.Equal("/", redirectResult?.Url);
		}

		[Theory]
		[InlineData("Ginni", "123")]
		public async Task CannotRegisterWithWrongPasswordLength(string username, string password)
		{
			// Arrange
			RegisterViewModel registerViewModel = new RegisterViewModel()
			{
				Username = username,
				Password = password
			};

			ApplicationUser user = new ApplicationUser
			{
				UserName = registerViewModel.Username,
				Email = registerViewModel.Email,
				FirstName = registerViewModel.FirstName,
				MiddleName = registerViewModel.MiddleName,
				LastName = registerViewModel.LastName
			};

			IQueryable<ApplicationUser> users = new List<ApplicationUser> { user }.AsQueryable();

			Mock<IUserStore<ApplicationUser>> userStore = new Mock<IUserStore<ApplicationUser>>();
			userStore.As<IUserPasswordStore<ApplicationUser>>().Setup(x => x.FindByNameAsync(username, CancellationToken.None)).ReturnsAsync(user);

			Mock<FakeUserManager> userManager = new Mock<FakeUserManager>();
			userManager.Setup(x => x.Users).Returns(users);

			if (password.Length >= 8)
			{
				userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
			}
			else
			{
				IdentityError[] erorrs = { new IdentityError() { Description = "Password must be 8 characters long and cannot be longer than 128 characters" } };
				userManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Failed(erorrs));
			}

			AccountController controller = new AccountController(userManager.Object, null);

			// Act
			ViewResult viewResult = (await controller.Register(registerViewModel)) as ViewResult;

			// Assert
			Assert.False(viewResult.ViewData.ModelState.IsValid);
		}
	}
}
