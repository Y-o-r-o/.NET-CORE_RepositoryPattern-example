using RepositoryLayer.Core;
using RepositoryLayer.DTOs;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastService
{
    public Task<Result<WeatherForecast>> GetTemperature(string latitude, string longtitude);
}
