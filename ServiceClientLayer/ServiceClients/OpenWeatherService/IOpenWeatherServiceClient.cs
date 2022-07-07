using Core;
using ServiceClientLayer.Models;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public interface IOpenWeatherServiceClient
{
    public Task<Result<WeatherForecast>> GetTemperatureAsync(double latitude, double longtitude);
}