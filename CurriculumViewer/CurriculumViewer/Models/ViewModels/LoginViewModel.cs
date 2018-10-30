using System.ComponentModel.DataAnnotations;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
	/// <summary>
	/// Represents a strongly typed login view model.
	/// </summary>
	public class LoginViewModel
    {
		/// <summary>
		/// The username of the user account.
		/// </summary>
		[Display(Name = "Gebruikersnaam")]
		[Required]
		[UIHint("Username")]
		public string Username { get; set; }

		/// <summary>
		/// The password of the user account.
		/// </summary>
		[Display(Name = "Wachtwoord")]
		[Required]
		[UIHint("Password")]
		public string Password { get; set; }

		/// <summary>
		/// The URL of the view the user came from post-login.
		/// </summary>
		public string ReturnUrl { get; set; } = "/";
	}
}
