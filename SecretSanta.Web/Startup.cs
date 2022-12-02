using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SecretSanta.Web
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
            var env = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
            
            services.AddRazorPages();
            services.AddServerSideBlazor();

            if (env.IsDevelopment() == false)
            {
                services.AddDbContext<Core.Domain.Contexts.SantaContext>(options =>
                    options.UseMySQL(Configuration.GetConnectionString("SantaContext")));
            }
            else
            {
                services.AddDbContext<Core.Domain.Contexts.SantaContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("SantaContext")));
                
                SeedTheDatabase(services.BuildServiceProvider());
            }

            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(Core.Queries.FetchWhoPersonPicked));
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            #if !DEBUG
            // Base directory
            app.UsePathBase("/SecretSanta");
            app.Use((context, next) =>
            {
                context.Request.PathBase = "/SecretSanta";
                return next();
            });
            #endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
        
        private void SeedTheDatabase(ServiceProvider service)
        {
            var db = service.GetRequiredService<Core.Domain.Contexts.SantaContext>();
            db.Database.EnsureCreated(); // Ensure the database is created.

            try
            {
                // Seed the database with test data.
                if (db.Peeps.Any() == false)
                {
                    db.Peeps.AddRange(Core.Domain.Contexts.Seeds.Seeder.Peeps());
                    db.SaveChanges();                            
                }

                if (db.Settings.Any() == false)
                {
                    db.Settings.Add(Core.Domain.Contexts.Seeds.Seeder.Settings());
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "An error occurred seeding the database. Error: {Message}", ex.Message);
            }
        }
    }
}
