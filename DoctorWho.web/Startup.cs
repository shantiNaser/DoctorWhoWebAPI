using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EF_DoctorWho.Db;
using EF_DoctorWho.Db.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DoctorWho.web
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<DoctorWhoCoreDbContext>
                (options => options.UseSqlServer
                (Configuration["ConnectionStrings:DB"]));


            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IEpsoideRepository, EpsoideRepository>();
            services.AddScoped<IEnemyRepository, EnemyRepository>();
            services.AddScoped<IEpisodeEnemyRepository, EpisodeEnemyRepository>();
            services.AddScoped<ICompanionRepository, CompanionRepository>();
            services.AddScoped<IEpisodeCompanionRepository, EpisodeCompanionRepository>();

            




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
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An unexpected fault happen ... Try again later");
                    });
                });
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
