using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodsPapa.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodsPapa
{
    public class Startup
    {
        private readonly IConfiguration con;

        public Startup(IConfiguration configuration)
        {
            con = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FoodDbContext>(opt => opt.UseSqlServer(con.GetConnectionString("cons")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<FoodDbContext>();
            services.Configure<IdentityOptions>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireNonAlphanumeric = false;
            });
            services.AddMvc(
                options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser().Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                }
                );
            services.AddTransient<IMemberRepository, SqlMemberRepository>();
        }

      
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
