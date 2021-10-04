using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MovieWebApplication.Repository;
using MovieWebApplication.Repository.RepositoryInterface;
using MovieWebApplication.Services;
using MovieWebApplication.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MovieWebApplication
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

            //service mapping
            services.AddSingleton<IMetadataService, MetadataService>();
            services.AddSingleton<IMovieService, MovieService>();


            services.AddSingleton<IMetadataRepository, MetadataRepository>();
            services.AddSingleton<IMoviesRepository, MoviesRepository>();
            services.AddSingleton<IQueryRepository, QueryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //removing colon from request
            app.Use(next => http =>
            {
                http.Request.Path = new PathString(http.Request.Path.Value.Replace(':',' '));
                return next(http);
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();


            //for handling http code exceptions
            app.UseStatusCodePages();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
