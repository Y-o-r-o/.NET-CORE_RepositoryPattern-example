using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories.Base;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace RepositoryLayer.RepositoryServices;

internal class WeatherForecastRepository : ServiceClientRepositoryBase<WeatherForecast>, IWeatherForecastRepository
{
    private IOpenWeatherServiceClient _openWeatherServiceClient;

    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient, CacheFactory cacheFactory) : base(cacheFactory)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<WeatherForecast?> GetWeatherAsync(double latitude, double longtitude)
        => await GetAsync(() => _openWeatherServiceClient.GetTemperatureAsync(latitude, longtitude));
        // new($"GetCachedWeatherAsync_{latitude}_{longtitude}")
        // {
        //     AbsoluteExpiration = new DateTimeOffset().AddMinutes(5),
        //     CachingService = CachingService.Redis
        // });

}