using Contracts.Service;
using Contracts;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Api.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<ILoggerManager, LoggerManager>();
        }
    }
}