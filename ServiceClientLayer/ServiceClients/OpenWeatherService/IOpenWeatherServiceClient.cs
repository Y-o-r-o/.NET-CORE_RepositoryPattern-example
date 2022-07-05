using Core;
using ServiceClientLayer.Models;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public interface IOpenWeatherServiceClient
{
    public Task<Result<WeatherForecast>> GetTemperature(double latitude, double longtitude);
}