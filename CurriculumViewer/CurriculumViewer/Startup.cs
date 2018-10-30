using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.Database;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.Infrastructure.SeedData;
using CurriculumViewer.Repository.EntityFramework;
using CurriculumViewer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xceed.Words.NET;

namespace CurriculumViewer
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationIdentityDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings:AppIdentity"]));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly("CurriculumViewer.Infrastructure")));
            services.AddTransient(typeof(IGenericRepository < >), typeof(EFGenericRepository < >));
            services.AddTransient(typeof(IGenericService< >), typeof(GenericService< >));
            services.AddTransient(typeof(IObjectFinderService< >), typeof(ObjectFinderService<>));
            services.AddTransient(typeof(IManyToManyMapperService< , , >), typeof(ManyToManyMapperService< , , >));
            services.AddTransient<IActivityLoggerService, ActivityDatabaseLoggerService>();
		    services.AddTransient(typeof(IGeneratorService<DocX>), typeof(DocxGeneratorService));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			UpdateDatabase(app);

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
			app.UseStaticFiles();
			app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
			    }
            );
		}

		private static void UpdateDatabase(IApplicationBuilder app)
		{
			using (IServiceScope serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				using (ApplicationDbContext context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
				using (ApplicationIdentityDbContext identityContext = serviceScope.ServiceProvider.GetService<ApplicationIdentityDbContext>())
				{
					identityContext.Database.Migrate();
					context.Database.Migrate();

                    // Seeding identity
				    UserManager<ApplicationUser> userMgr =
				        serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
				    RoleManager<IdentityRole> roleMgr =
				        serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                    IdentitySeedData identitySeeder = new IdentitySeedData(identityContext, userMgr, roleMgr);
                    identitySeeder.Seed();

					try
					{
						SeedData.EnsurePopulated(context);
					}
					catch (Exception ex)
					{
						ILogger<Startup> logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Startup>>();
						logger.LogError(ex, "An error occured seeding the database.");
					}
				}
			}
		}
	}
}
