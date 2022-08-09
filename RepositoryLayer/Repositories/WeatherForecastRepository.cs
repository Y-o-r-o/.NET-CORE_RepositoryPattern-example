using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories.Base;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace RepositoryLayer.RepositoryServices;

internal class WeatherForecastRepository : ServiceClientRepositoryBase<WeatherForecast>, IWeatherForecastRepository
{
    private IOpenWeatherServiceClient _openWeatherServiceClient;

    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient, Cache cache) : base(cache)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<WeatherForecast?> GetWeatherAsync(double latitude, double longtitude)
        => await GetAsync(() => _openWeatherServiceClient.GetTemperatureAsync(latitude, longtitude));

    public async Task<WeatherForecast?> GetCachedWeatherAsync(double latitude, double longtitude)
        => await GetAsync(() => _openWeatherServiceClient.GetTemperatureAsync(latitude, longtitude), new());

}