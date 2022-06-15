using RepositoryLayer.DTOs;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Extensions;
using Microsoft.Extensions.Options;
using RepositoryLayer.Core;

namespace RepositoryLayer.RepositoryServices;

public class WeatherForecastService : IWeatherForecastService
{

    private string _apiKey;
    private HttpClient _httpClient;

    public WeatherForecastService(HttpClient httpClient, IOptions<OpenWeatherMapSettings> config)
    {
        _apiKey = config.Value.ApiKey;
        _httpClient = httpClient;
    }

    public async Task<Result<WeatherForecast>> GetTemperature(string latitude, string longtitude)
    {
        var parameters = new List<(string, string)>()
        {
            ("lat", latitude),
            ("lon", longtitude),
            ("appid", _apiKey)
        };

        var response = await _httpClient.GetAsync("data/2.5/weather", parameters);

        if (response.IsSuccessStatusCode){
            var weatherForecast = await response.Content.Read<WeatherForecast>();
            return Result<WeatherForecast>.Success(weatherForecast);
        }

        return Result<WeatherForecast>.Failure("...some error");
    }

}