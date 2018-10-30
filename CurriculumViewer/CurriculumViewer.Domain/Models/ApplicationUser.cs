using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CurriculumViewer.Domain.Models
{
	public class ApplicationUser : IdentityUser
	{
		/// <summary>
		/// Gets or sets the first name of the user.
		/// </summary>
		[Display(Name = "Voornaam")]
		public string FirstName { get; set; }

		/// <summary>
		/// Gets or sets the middle name of the user.
		/// </summary>
		[Display(Name = "Tussenvoegsel")]
		public string MiddleName { get; set; }

		/// <summary>
		/// Gets or sets the last name of the user.
		/// </summary>
		[Display(Name = "Achternaam")]
		public string LastName { get; set; }

		/// <summary>
		/// Gets the full name of the user.
		/// </summary>
		/// <returns>The full name of the user.</returns>
		public string FullName
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append($"{FirstName}");

				if (!string.IsNullOrWhiteSpace(MiddleName))
				{
					stringBuilder.Append($" {MiddleName}");
				}

				stringBuilder.Append($" {LastName}");
				return stringBuilder.ToString();
			}
		}
	}
}
