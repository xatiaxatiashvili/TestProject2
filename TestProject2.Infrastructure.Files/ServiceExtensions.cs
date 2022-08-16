using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject2.Core.Application.Interfaces.Contracts;

namespace TestProject2.Infrastructure.Files
{
    public static class ServiceExtensions
    {
        public static void AddFilesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFileManager, FileManager>();
        }
    }
}
