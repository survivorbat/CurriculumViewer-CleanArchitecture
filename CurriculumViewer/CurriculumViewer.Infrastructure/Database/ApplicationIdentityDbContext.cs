using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurriculumViewer.Database
{
	/// <summary>
	/// A DbContext instance represents a session with the database and can be used to 
	/// query and save instances of your entities. DbContext is a combination of the 
	/// Unit Of Work and Repository patterns. This class is for the Entity Framework 
	/// database context used for identity.
	/// </summary>
	public class ApplicationIdentityDbContext : IdentityDbContext<IdentityUser>
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationIdentityDbContext"/> class.
		/// </summary>
		/// <param name="options">The options used by a <see cref="ApplicationIdentityDbContext"/>.</param>
		public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
