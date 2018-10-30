using System.ComponentModel.DataAnnotations;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
	/// <summary>
	/// Represents a strongly typed register view model.
	/// </summary>
	public class RegisterViewModel
    {
		/// <summary>
		/// The first name of the user.
		/// </summary>
		[Required]
		[Display(Name = "Voornaam")]
		[StringLength(64, MinimumLength = 1, ErrorMessage = "Een voornaam kan niet langer zijn dan 64 karakters.")]
		public string FirstName { get; set; }

		/// <summary>
		/// The middle name of the user.
		/// </summary>
		[Display(Name = "Tussenvoegsel")]
		public string MiddleName { get; set; }

		/// <summary>
		/// The last name of the user.
		/// </summary>
		[Required]
		[Display(Name = "Achternaam")]
		[StringLength(64, MinimumLength = 1, ErrorMessage = "Een achternaam kan niet langer zijn dan 64 karakters.")]
		public string LastName { get; set; }

		/// <summary>
		/// The username of the user account.
		/// </summary>
		[Required]
		[Display(Name = "Gebruikersnaam")]
		[StringLength(64, ErrorMessage = "Een gebruikersnaam kan niet langer zijn dan 64 karakters.", MinimumLength = 1)]
		public string Username { get; set; }

		/// <summary>
		/// The email address of the user account.
		/// </summary>
		[Required]
		[Display(Name = "Emailadres")]
		[EmailAddress(ErrorMessage = "Emailadres is onjuist")]
		public string Email { get; set; }


		/// <summary>
		/// The password of the user account.
		/// </summary>
		[Required]
		[Display(Name = "Wachtwoord")]
		[DataType(DataType.Password)]
		[StringLength(128, MinimumLength = 8, ErrorMessage = "Een wachtwoord moet minimal 8 karakters lang zijn en kan niet langer zijn dan 128 karakters.")]
		public string Password { get; set; }

		/// <summary>
		/// The confirmation password of the user account.
		/// </summary>
		[Display(Name = "Herhaal wachtwoord")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Wachtwoord komt niet overeen.")]
		public string ConfirmPassword { get; set; }
	}
}
