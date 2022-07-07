using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using RepositoryLayer.Repositories.Base;

namespace RepositoryLayer.RepositoryServices;

internal class WeatherForecastRepository : ServiceClientRepositoryBase<WeatherForecast>, IWeatherForecastRepository
{

    private IOpenWeatherServiceClient _openWeatherServiceClient;

    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<WeatherForecast?> GetWeatherAsync(double latitude, double longtitude)
        => await GetAsync(_openWeatherServiceClient.GetTemperatureAsync, latitude, longtitude);

}