﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $ext_safeprojectname$.Core.Repositories
{
    public interface IWeatherRepository
    {
        IEnumerable<Models.WeatherForecast> Get();
    }
}
