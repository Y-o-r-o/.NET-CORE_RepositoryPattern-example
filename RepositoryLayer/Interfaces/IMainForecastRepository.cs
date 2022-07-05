using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;

public interface IMainForecastRepository
{
    public Task<MainForecast> GetWeatherAsync(double latitude, double longtitude);
}
