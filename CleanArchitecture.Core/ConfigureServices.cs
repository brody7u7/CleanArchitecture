using $ext_safeprojectname$.Core.Interfaces;
using $ext_safeprojectname$.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace $ext_safeprojectname$.Extensions.DependencyInjection
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
