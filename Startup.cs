using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMovies.Services;
using MyMovies.Services.Interfaces;

namespace MyMovies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MyMoviesDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IMovieService, MovieService>();
            services.AddCors(options =>
            {
                options.AddPolicy("FrontendClient", builder =>
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:8080")
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("FrontendClient");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
