using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using RepositoryLayer.Repositories.Base;

namespace RepositoryLayer.RepositoryServices;

internal class MainForecastRepository : ServiceClientRepositoryBase<MainForecast>, IMainForecastRepository
{

    private IOpenWeatherServiceClient _openWeatherServiceClient;

    public MainForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient, IServiceProvider service) : base(service)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<MainForecast?> GetWeatherAsync(double latitude, double longtitude)
        => await GetAsync(_openWeatherServiceClient.GetTemperature, latitude, longtitude);

}