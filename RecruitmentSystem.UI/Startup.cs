using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RecruitmentSystem.Domain.Entities;
using RecruitmentSystem.Infrastructure.Data;
using RecruitmentSystem.UI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using RecruitmentSystem.UI.Infrastructure.Filters;

namespace RecruitmentSystem.UI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();
            services.AddDbContext<AuthDbContext>();
            // IDENTITY

            services.AddDefaultIdentity<UsuarioIdentity>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AuthDbContext>();

            // Setup Dependency injection
            services.AddDependencies();

            // PROTECT All PAGES
            var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
            services.AddControllersWithViews(options => {
                options.Filters.Add(new AuthorizeFilter(policy));
                options.Filters.Add(typeof(CustomAuthFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            var staticOptions = new StaticFileOptions() { ServeUnknownFileTypes = true };
            app.UseStaticFiles(staticOptions);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
