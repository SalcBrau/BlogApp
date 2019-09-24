using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Data;
using Data.Repo;
using Data.Repo.Implementations;
using Data.Repo.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace BlogApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        private readonly IHostingEnvironment _environment;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.None;
                options.Secure = _environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
            });
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = _environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.Cookie.Name = "TechLifeAuthCookie";
                    options.LoginPath = "/Login";                 
                });

            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "logout",
                    template: "Logout",
                    defaults: new { controller = "Admin", action = "Logout"}
                );
                routes.MapRoute(
                    name: "login",
                    template: "Login",
                    defaults: new { controller = "Admin", action = "Login" }
                );
                routes.MapRoute(
                    name: "post",
                    template: "Archive/{year}/{month}/{title}",
                    defaults: new { controller = "Blog", action = "Post" }
                );
                routes.MapRoute(
                  name: "tag",
                  template: "Tag/{tag}",
                  defaults: new { controller = "Blog", action = "Tag" }
                );
                routes.MapRoute(
                    name: "category",
                    template: "Category/{category}",
                    defaults: new { controller = "Blog", action = "Category" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
