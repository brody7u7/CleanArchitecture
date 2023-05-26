using $ext_safeprojectname$.Core.Repositories;
using $ext_safeprojectname$.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace $ext_safeprojectname$.Extensions.DependencyInjection
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
