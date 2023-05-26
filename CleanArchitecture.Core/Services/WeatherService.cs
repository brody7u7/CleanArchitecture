using $ext_safeprojectname$.Core.Interfaces;
using $ext_safeprojectname$.Core.Models;
using $ext_safeprojectname$.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $ext_safeprojectname$.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherRepository.Get();
        }
    }
}
