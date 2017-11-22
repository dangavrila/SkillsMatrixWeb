using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SkillsMatrixWeb.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace SkillsMatrixWeb
{
    public class Startup
    {
        private readonly IConfigurationRoot _config;
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            services.AddLogging();

            services.AddDbContext<SkillsMatrixDbContext>();

            services.AddTransient<SeedDataSkillsMatrixContext>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<SkillsMatrixDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(config =>
            {
                // Password settings
                config.Password.RequireDigit = true;
                config.Password.RequiredLength = 8;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = true;
                config.Password.RequireLowercase = false;
                config.Password.RequiredUniqueChars = 6;

                // Lockout settings
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                config.Lockout.MaxFailedAccessAttempts = 10;
                config.Lockout.AllowedForNewUsers = true;

                // User settings
                config.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/Auth/Login";
                options.LogoutPath = "/Auth/Logout";
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.SlidingExpiration = true;
            });
            
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            services.AddScoped<ITechnologyRepository, TechnologyRepository>();

            services.AddScoped<IEmployeesRepository, EmployeesRepository>();

            services
                .AddMvc();
                //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddKendo();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            SeedDataSkillsMatrixContext seed)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            app.UseKendo(env);

            seed.EnsureSeedDataAsync().Wait();
        }
    }
}
