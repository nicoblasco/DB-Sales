using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using waSales.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace waSales.Web
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
            services.AddControllers();
            // ********************
            // Setup CORS
            // ********************
            //var corsBuilder = new CorsPolicyBuilder();
            //corsBuilder.AllowAnyHeader();
            //corsBuilder.AllowAnyMethod();
            //corsBuilder.AllowAnyOrigin(); // For anyone access.
            //                              // corsBuilder.WithOrigins("http://localhost:8080/"); // for a specific url. Don't add a forward slash on the end!
            //corsBuilder.AllowCredentials();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // services.AddMvc().AddJsonOptions(  options => options.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<DbContextApp>(options => options.UseSqlServer(Configuration.GetConnectionString("Conexion")));




            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc();
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
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors("SiteCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapFallbackToController("Get", "Values");
            });
            //app.UseMvc(routes => {
            //    routes.MapRoute(name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //    routes.MapSpaFallbackRoute(
            //    name: "spa-fallback",
            //    defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
