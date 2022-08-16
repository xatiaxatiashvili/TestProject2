using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestProject2.Core.Application.Interfaces.Repositories;
using TestProject2.Infrastructure.Persistence.Implamentations;

namespace TestProject2.Infrastructure.Persistence
{
    public static class ServiceExtentions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           
        }
    }
}
