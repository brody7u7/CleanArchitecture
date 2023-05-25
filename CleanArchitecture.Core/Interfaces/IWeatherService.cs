namespace CleanArchitecture.Core.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<Models.WeatherForecast> Get();
    }
}
