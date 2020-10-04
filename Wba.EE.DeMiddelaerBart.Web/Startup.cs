﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;

namespace Wba.EE.DeMiddelaerBart.Web
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<CookiePolicyOptions>(options =>
            {
                //https://stackoverflow.com/questions/52601190/httpcontext-session-not-maintaining-state
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false; // <--- mijn probleem was dit -_- moest false zijn
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // adding DB context ----------------------------------------------------------
            services.AddDbContext<SiteContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            //-----------------------------------------------------------------------------

            // Session --------------------------------------------------------------------     

            services.AddMemoryCache();
            services.AddSession();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
       
            // ----------------------------------------------------------------------------        
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
         
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });       

        }
    }
}
