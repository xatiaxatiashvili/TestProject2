using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TestProject2.Core.Application;
using TestProject2.Infrastructure.Persistence;
using TestProject2.Presentation.WebApi.Extensions.Middlewares;

namespace TestProject2.Presentation.WebApi
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
            services.AddThisLayer(Configuration);
         //   services.AddControllers();
            services.AddApplicationLayer(Configuration);   
            services.AddPersistenceLayer(Configuration);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestProject2.Presentation.WebApi", Version = "v1" });
            });
        
        }

     
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestProject2.Presentation.WebApi v1"));
            }
            app.UseMiddleware<ExceptionHandler>();
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
