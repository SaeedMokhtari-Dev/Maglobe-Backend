using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Maglobe.Core.Constants;
using Maglobe.Web.Configuration.Constants;
using Maglobe.Web.Identity.Middleware;
using Maglobe.Web.Initializers;
using Maglobe.Web.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Maglobe.Web
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
            services
                .AddSingleton(Configuration)
                .ConfigureCors(Configuration)
                .ConfigureLogger(Configuration)
                .ConfigureDatabase(Configuration)
                .ConfigureOptions(Configuration)
                .ConfigureAuthentication(Configuration)
                .ConfigureAuthorization()
                .ConfigureServicesByConvention(Assembly.GetExecutingAssembly());
            
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddMvcCore().AddApiExplorer();
            
            services.ConfigureSwagger();
            services.AddResponseCaching();
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/Index", "");
            });
            services.AddRazorPages();
            //services.AddControllersWithViews();
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            SetCulture();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint(Endpoints.Swagger, "Maglube Portal v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(Policies.CorsPolicy);
            app.Use(async (context, nextMiddleware) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("API-Server-Version", GetType().Assembly.GetName().Version?.ToString());
                    return Task.FromResult(0);
                });
                await nextMiddleware();
            });
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseUserContext();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                
            });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                /*if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }*/
            });
        }
        private static void SetCulture()
        {
            var cultureInfo = new CultureInfo("en");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}