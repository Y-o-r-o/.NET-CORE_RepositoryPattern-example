using Core;
using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IWeatherForecastRepository
{
     public Task<Result<Main>> GetWeather(string latitude, string longtitude);

}
