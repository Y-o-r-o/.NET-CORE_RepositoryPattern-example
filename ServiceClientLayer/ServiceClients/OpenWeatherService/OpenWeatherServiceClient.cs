using Core;
using ServiceClientLayer.Models;
using ServiceClientLayer.Extensions;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public class OpenWeatherServiceClient : IOpenWeatherServiceClient
{
    private string _apiKey;
    private HttpClient _httpClient;

    public OpenWeatherServiceClient(HttpClient httpClient, OpenWeatherMapSettings openWeatherMapSettings)
    {
        _apiKey = openWeatherMapSettings.ApiKey;
        _httpClient = httpClient;
    }

    public async Task<Result<WeatherForecast>> GetTemperature(double latitude, double longtitude)
    {
        var parameters = new List<(string, string)>(){
            ("lat", latitude.ToString()),
            ("lon", longtitude.ToString()),
            ("appid", _apiKey)};

        var response = await _httpClient.GetAsync("data/2.5/weather", parameters);

        if (response.IsSuccessStatusCode)
        {
            var weatherForecast = await response.Content.Read<WeatherForecast>();
            return Result<WeatherForecast>.Success(weatherForecast);
        }

        return Result<WeatherForecast>.Failure("OpenWeatherMap api error: " + response.StatusCode.ToString());
    }

}