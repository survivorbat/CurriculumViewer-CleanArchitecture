using AspNetCore.Hateoas.Infrastructure;
using CurriculumViewer.Abstract.Repository;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.API.v1.Constants;
using CurriculumViewer.API.v1.Extensions;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.ApplicationServices.Services;
using CurriculumViewer.Database;
using CurriculumViewer.Domain.Models;
using CurriculumViewer.Repository.EntityFramework;
using CurriculumViewer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CurriculumViewer.API.v1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = ShouldSerializeContractResolver.Instance,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => {
                options.RespectBrowserAcceptHeader = true;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddXmlSerializerFormatters()
                .AddHateoas(options => {
                    options
                        .AddLink<Domain.Models.Module>(ModuleRoutes.GET_MODULE, p => new { Id = p.Id })
                        .AddLink<List<Domain.Models.Module>>(ModuleRoutes.GET_MODULES)
                        .AddLink<List<Domain.Models.Module>>(ModuleRoutes.POST_MODULES)
                        .AddLink<Domain.Models.Module>(ModuleRoutes.PUT_MODULE, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(ModuleRoutes.POST_MODULES)
                        .AddLink<Domain.Models.Module>(ModuleRoutes.DELETE_MODULE, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(ModuleRoutes.GET_MODULE_EXAMS, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(ModuleRoutes.GET_MODULE_GOALS, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(ModuleRoutes.POST_MODULE_EXAMS, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(ModuleRoutes.POST_MODULE_GOALS, p => new { Id = p.Id })
                        .AddLink<Domain.Models.Module>(TeacherRoutes.GET_TEACHER, p => new { Id = p.Teacher.Id })
                        .AddLink<Domain.Models.Module>(TeacherRoutes.PUT_TEACHER, p => new { Id = p.Teacher.Id })
                        .AddLink<Domain.Models.Module>(TeacherRoutes.POST_TEACHER)
                        .AddLink<Domain.Models.Module>(TeacherRoutes.DELETE_TEACHER, p => new { Id = p.Teacher.Id })

                        .AddLink<Teacher>(TeacherRoutes.GET_TEACHER, p => new { Id = p.Id })
                        .AddLink<List<Teacher>>(TeacherRoutes.GET_TEACHERS)
                        .AddLink<Teacher>(TeacherRoutes.PUT_TEACHER, p => new { Id = p.Id })
                        .AddLink<Teacher>(TeacherRoutes.DELETE_TEACHER, p => new { Id = p.Id })
                        .AddLink<Teacher>(TeacherRoutes.GET_TEACHER_COURSES, p => new { Id = p.Id })
                        .AddLink<Teacher>(TeacherRoutes.GET_TEACHER_MODULES, p => new { Id = p.Id })
                        .AddLink<Teacher>(TeacherRoutes.GET_TEACHER_EXAMS, p => new { Id = p.Id })

                        .AddLink<Course>(CourseRoutes.GET_COURSE, p => new { Id = p.Id })
                        .AddLink<Course>(CourseRoutes.PUT_COURSE, p => new { Id = p.Id })
                        .AddLink<Course>(CourseRoutes.DELETE_COURSE, p => new { Id = p.Id })
                        .AddLink<List<Course>>(CourseRoutes.GET_COURSES)
                        .AddLink<Course>(CourseRoutes.GET_COURSE_MODULES, p => new { Id = p.Id })
                        .AddLink<Course>(TeacherRoutes.GET_TEACHER, p => new { Id = p.Mentor.Id })
                        .AddLink<Course>(TeacherRoutes.PUT_TEACHER, p => new { Id = p.Mentor.Id })
                        .AddLink<Course>(TeacherRoutes.POST_TEACHER)
                        .AddLink<Course>(TeacherRoutes.DELETE_TEACHER, p => new { Id = p.Mentor.Id })

                        .AddLink<List<Exam>>(ExamRoutes.GET_EXAMS)
                        .AddLink<Exam>(ExamRoutes.GET_EXAM, p => new { Id = p.Id })
                        .AddLink<Exam>(ExamRoutes.POST_EXAM, p => new { Id = p.Id })
                        .AddLink<Exam>(ExamRoutes.DELETE_EXAM, p => new { Id = p.Id })
                        .AddLink<Exam>(ExamRoutes.PUT_EXAM, p => new { Id = p.Id })
                        .AddLink<Exam>(TeacherRoutes.GET_TEACHER, p => new { Id = p.ResponsibleTeacher.Id })
                        .AddLink<Exam>(TeacherRoutes.PUT_TEACHER, p => new { Id = p.ResponsibleTeacher.Id })
                        .AddLink<Exam>(TeacherRoutes.POST_TEACHER)
                        .AddLink<Exam>(TeacherRoutes.DELETE_TEACHER, p => new { Id = p.ResponsibleTeacher.Id })

                        .AddLink<List<LogItem>>(LogItemRoutes.GET_LOGITEMS)
                        .AddLink<LogItem>(LogItemRoutes.GET_LOGITEM, p => new { Id = p.Id })

                        .AddLink<List<ExamProgram>>(ExamProgramRoutes.GET_EXAMPROGRAMS)
                        .AddLink<List<ExamProgram>>(ExamProgramRoutes.PUT_EXAMPROGRAMS)
                        .AddLink<List<ExamProgram>>(ExamProgramRoutes.POST_EXAMPROGRAM)
                        .AddLink<List<ExamProgram>>(ExamProgramRoutes.DELETE_EXAMPROGRAMS)
                        .AddLink<ExamProgram>(ExamProgramRoutes.GET_EXAMPROGRAM, p => new { Id = p.Id })
                        .AddLink<ExamProgram>(ExamProgramRoutes.PUT_EXAMPROGRAM, p => new { Id = p.Id })
                        .AddLink<ExamProgram>(ExamProgramRoutes.POST_EXAMPROGRAM)
                        .AddLink<ExamProgram>(ExamProgramRoutes.DELETE_EXAMPROGRAM, p => new { Id = p.Id })
                        .AddLink<ExamProgram>(ExamProgramRoutes.GET_EXAMPROGRAM_COURSES, p => new { Id = p.Id })

                        .AddLink<List<Goal>>(GoalRoutes.GET_GOALS)
                        .AddLink<List<Goal>>(GoalRoutes.POST_GOAL)
                        .AddLink<Goal>(GoalRoutes.GET_GOAL, p => new { Id = p.Id })
                        .AddLink<Goal>(GoalRoutes.DELETE_GOAL, p => new { Id = p.Id })
                        .AddLink<Goal>(GoalRoutes.POST_GOAL)
                        .AddLink<Goal>(GoalRoutes.PUT_GOAL, p => new { Id = p.Id })

                        .AddLink<LearningLine>(LearningLineRoutes.GET_LEARNINGLINE, p => new { Id = p.Id })
                        .AddLink<List<LearningLine>>(LearningLineRoutes.POST_LEARNINGLINE)
                        .AddLink<List<LearningLine>>(LearningLineRoutes.GET_LEARNINGLINES)
                        .AddLink<LearningLine>(LearningLineRoutes.POST_LEARNINGLINE)
                        .AddLink<LearningLine>(LearningLineRoutes.PUT_LEARNINGLINE, p => new { Id = p.Id })
                        .AddLink<LearningLine>(LearningLineRoutes.DELETE_LEARNINGLINE, p => new { Id = p.Id })
                        .AddLink<LearningLine>(LearningLineRoutes.GET_LEARNINGLINE_GOALS, p => new { Id = p.Id })
                     ;
                })
                .AddXmlDataContractSerializerFormatters();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly("CurriculumViewer.Infrastructure")));
            services.AddTransient<IGenericRepositoryV2, EFGenericRepositoryV2>();
            services.AddTransient<IGenericServiceV2, GenericServiceV2>();
            services.AddTransient(typeof(IObjectFinderService<>), typeof(ObjectFinderService<>));
            services.AddTransient(typeof(IManyToManyMapperService<,,>), typeof(ManyToManyMapperService<,,>));
            services.AddTransient(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddTransient<IActivityLoggerService, ActivityDatabaseLoggerService>();

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {
                    Title = "Curriculumviewer API",
                    Version = "v1",
                    Description = "The API of the CurriculumViewer that is used by Avans University to manage the curricula",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Email = "contact@avans.nl",
                        Name = "Avans University",
                        Url = "https://avans.nl"
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseSwagger(e => { });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurriculumViewer API v1");
                c.RoutePrefix = "";
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "/api/v1/{controller}/{action=Index}/{id?}");
            });
        }
    }
}
