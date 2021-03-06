using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Webgentle.BookStore.ClaimsForRegisteredUser;
using Webgentle.BookStore.Models;
using Webgentle.BookStore.Repository;
using Webgentle.BookStore.Service;

namespace Webgentle.BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MovieConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
            services.AddScoped<MovieRepository, MovieRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            //to use custom claims we add this service with intereface and its implementation
           // services.AddScoped <IUserClaimsPrincipalFactory<ApplicationUser>,ApplicationUserClaimsPrincipalFactory>();
            //for redierect user to signIn page if not authorized to see some page
            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/account/signin";
            });
            services.AddScoped<IUserService, UserService>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                 endpoints.MapDefaultControllerRoute();
                //endpoints.MapControllerRoute(
                //    name: "Default",
                //    pattern: "moviestore/{controller=Home}/{action=index}/{id?)}");
            });
           
        }
    }
}
