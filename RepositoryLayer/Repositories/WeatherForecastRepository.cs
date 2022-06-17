using Core;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using AutoMapper;

namespace RepositoryLayer.RepositoryServices;

public class WeatherForecastRepository : IWeatherForecastRepository
{

    private IOpenWeatherServiceClient _openWeatherServiceClient;
    private readonly IMapper _mapper;


    public WeatherForecastRepository(IOpenWeatherServiceClient openWeatherServiceClient, IMapper mapper)
    {
        _openWeatherServiceClient = openWeatherServiceClient;
        _mapper = mapper;
    }

    public async Task<Result<WeatherForecast>> GetTemperature(string latitude, string longtitude)
    {
        var response = await _openWeatherServiceClient.GetTemperature(latitude, longtitude);

        if (response.IsSuccess)
        {
            var weatherForecast = _mapper.Map<WeatherForecast>(response.Value);
        }

        throw new NotImplementedException();
    }
}