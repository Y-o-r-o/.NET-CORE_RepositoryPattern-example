using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastRepository
{
    public Task<WeatherForecast?> GetWeatherAsync(double latitude, double longtitude);
}
