using Core;
using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastRepository
{
     public Task<MainForecast> GetWeatherAsync(string latitude, string longtitude);

}
