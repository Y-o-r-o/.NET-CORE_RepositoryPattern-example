using Core;
using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastRepository
{
     public Task<MainForecast> GetWeather(string latitude, string longtitude);

}
