using Core;
using ServiceClientLayer.Models;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public interface IOpenWeatherServiceClient
{
    public Task<Result<WeatherForecast>> GetTemperature(string latitude, string longtitude);
}