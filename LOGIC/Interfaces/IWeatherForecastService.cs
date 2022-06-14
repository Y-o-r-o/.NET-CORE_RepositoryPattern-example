using API;

namespace LOGIC.Interfaces;

public interface IWeatherForecastService
{
    public IEnumerable<WeatherForecast> Get();
}
