using Core;
using ServiceClientLayer.Models;
using ServiceClientLayer.Extensions;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public class OpenWeatherServiceClient : IOpenWeatherServiceClient
{
    const int MAXIMUM_VALID_LATITUDE = 90;
    const int MINIMUM_VALID_LATITUDE = -90;
    const int MAXIMUM_VALID_LONGTITUDE = 180;
    const int MINIMUM_VALID_LONGTITUDE = -180;

    private string _apiKey;
    private HttpClient _httpClient;

    public OpenWeatherServiceClient(HttpClient httpClient, OpenWeatherMapSettings openWeatherMapSettings)
    {
        _apiKey = openWeatherMapSettings.ApiKey;
        _httpClient = httpClient;
    }

    public async Task<Result<WeatherForecast>> GetTemperature(double latitude, double longtitude)
    {
        if (latitude > MAXIMUM_VALID_LATITUDE || latitude < MINIMUM_VALID_LATITUDE)
        {
            throw new ArgumentException($"Latitude out of range. Range must be >={MAXIMUM_VALID_LATITUDE} and <={MINIMUM_VALID_LATITUDE}. Given: {latitude}");
        }
        if (longtitude > MAXIMUM_VALID_LONGTITUDE || longtitude < MINIMUM_VALID_LONGTITUDE)
        {
            throw new ArgumentException($"Longtitude out of range. Range must be >={MAXIMUM_VALID_LONGTITUDE} and <={MINIMUM_VALID_LONGTITUDE}. Given: {longtitude}");
        }

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