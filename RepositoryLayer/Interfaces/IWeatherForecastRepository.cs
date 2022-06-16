
using Core;
using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastRepository
{
     public Task<Result<WeatherForecast>> GetTemperature(string latitude, string longtitude);
}
