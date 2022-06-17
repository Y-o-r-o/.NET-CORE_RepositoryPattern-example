using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using RepositoryLayer.Mappers;

namespace RepositoryLayer.RepositoryServices;

public class WeatherForecastRepository : IWeatherForecastRepository
{

    private IOpenWeatherServiceClient _openWeatherServiceClient;


    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<MainForecast> GetWeather(string latitude, string longtitude)
    {
        var response = await _openWeatherServiceClient.GetTemperature(latitude, longtitude);

        MainForecast mainForecast = null;

        if (response.IsSuccess)
        {
            mainForecast = MappingProfiles.Map(response.Value).Main;
        }

        return mainForecast;
    }
}