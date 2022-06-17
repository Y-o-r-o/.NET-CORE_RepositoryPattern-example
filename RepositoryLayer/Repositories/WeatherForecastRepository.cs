using Core;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using AutoMapper;
using RepositoryLayer.Mappers;

namespace RepositoryLayer.RepositoryServices;

public class WeatherForecastRepository : IWeatherForecastRepository
{

    private IOpenWeatherServiceClient _openWeatherServiceClient;


    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
    }

    public async Task<Result<Main>> GetWeather(string latitude, string longtitude)
    {
        var response = await _openWeatherServiceClient.GetTemperature(latitude, longtitude);

        if (response.IsSuccess)
        {
            var mainForecast = MappingProfiles.Map(response.Value).Main;
            return mainForecast is null ?
                Result<Main>.Failure("MainForecast is null") :
                Result<Main>.Success(mainForecast);
        }

        return Result<Main>.Failure(response.Error);
    }
}