using $ext_safeprojectname$.Core.Configuration;
using $ext_safeprojectname$.Core.Interfaces;
using $ext_safeprojectname$.Core.Models;
using $ext_safeprojectname$.Core.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $ext_safeprojectname$.Infrastructure.Repositories
{
    public class WeatherRepository : Repository, IWeatherRepository
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherRepository(IOptions<ApiSettings> options, 
                                 ICurrentUserService currentUserService, 
                                 ILogger<WeatherRepository> logger) : base(options, currentUserService, logger)
        {
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
        }
    }
}
