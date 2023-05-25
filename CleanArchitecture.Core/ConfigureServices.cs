using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherService, WeatherService>();

            return services;
        }
    }
}
