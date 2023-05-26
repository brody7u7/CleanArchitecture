namespace $ext_safeprojectname$.Core.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<Models.WeatherForecast> Get();
    }
}
