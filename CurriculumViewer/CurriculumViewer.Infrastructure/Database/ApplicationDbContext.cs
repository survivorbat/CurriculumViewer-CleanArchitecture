using CurriculumViewer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CurriculumViewer.Database
{
	/// <summary>
	/// A DbContext instance represents a session with the database and can be used to 
	/// query and save instances of your entities. DbContext is a combination of the 
	/// Unit Of Work and Repository patterns.
	/// </summary>
	public class ApplicationDbContext : DbContext
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
		/// </summary>
		/// <param name="options">The options used by a <see cref="DbContext"/>.</param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		/// <summary>
		/// Configures the schema needed for the identity framework.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Course>().HasKey(c => new { c.Id });
			modelBuilder.Entity<Module>().HasKey(m => new { m.Id });
			modelBuilder.Entity<Exam>().HasKey(e => new { e.Id });
			modelBuilder.Entity<Goal>().HasKey(g => new { g.Id });
			modelBuilder.Entity<ExamProgram>().HasKey(s => new { s.Id });
		    modelBuilder.Entity<Teacher>().HasKey(t => new {t.Id});
            modelBuilder.Entity<Module>().HasMany(m => m.Exams);
			modelBuilder.Entity<Module>().HasMany(m => m.Goals);
			modelBuilder.Entity<ExamProgram>().HasMany(s => s.Courses);
            modelBuilder.Entity<CourseModule>().HasKey(sc => new { sc.CourseId, sc.ModuleId });
		    modelBuilder.Entity<TeacherModule>().HasKey(sc => new { sc.TeacherId, sc.ModuleId });
            modelBuilder.Entity<LearningLineGoal>().HasKey(e => new { e.LearningLineId, e.GoalId });
        }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<Teacher> Teachers { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<TeacherModule> TeacherModules { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<Exam> Exams { get; set; }

        /// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<LearningLine> LearningLines { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<LearningLineGoal> LearningLineGoals { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<Course> Courses { get; set; }

        /// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<LogItem> LogItems { get; set; }

        /// <summary>
        /// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
        /// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
        /// be translated into queries against the database.
        /// </summary>
        public DbSet<ExamProgram> ExamPrograms { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<Module> Modules { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<CourseModule> CourseModules { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<EuropeanCompetence> EuropeanCompetences { get; set; }

		/// <summary>
		/// A <see cref="DbSet{TEntity}"/> can be used to query and save instances
		/// of TEntity. LINQ queries against a <see cref="DbSet{TEntity}"/> will
		/// be translated into queries against the database.
		/// </summary>
		public DbSet<Goal> Goals { get; set; }
	}
}
