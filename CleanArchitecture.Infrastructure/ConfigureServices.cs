using CleanArchitecture.Core.Repositories;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherRepository, WeatherRepository>();

            return services;
        }
    }
}
