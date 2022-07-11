using Core;
using ServiceClientLayer.Models;
using ServiceClientLayer.Extensions;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public class OpenWeatherServiceClient : IOpenWeatherServiceClient
{
    const double MAXIMUM_VALID_LATITUDE = 90;
    const double MINIMUM_VALID_LATITUDE = -90;
    const double MAXIMUM_VALID_LONGTITUDE = 180;
    const double MINIMUM_VALID_LONGTITUDE = -180;

    private string? _apiKey;
    private HttpClient _httpClient;

    public OpenWeatherServiceClient(HttpClient httpClient, OpenWeatherMapSettings openWeatherMapSettings)
    {
        _apiKey = openWeatherMapSettings.ApiKey;
        _httpClient = httpClient;
    }

    public async Task<Result<WeatherForecast>> GetTemperatureAsync(double latitude, double longtitude)
    {
        if (latitude > MAXIMUM_VALID_LATITUDE || latitude < MINIMUM_VALID_LATITUDE)
        {
            throw new ArgumentException($"Latitude out of range. Range must be >={MAXIMUM_VALID_LATITUDE} and <={MINIMUM_VALID_LATITUDE}. Given: {latitude}");
        }
        if (longtitude > MAXIMUM_VALID_LONGTITUDE || longtitude < MINIMUM_VALID_LONGTITUDE)
        {
            throw new ArgumentException($"Longtitude out of range. Range must be >={MAXIMUM_VALID_LONGTITUDE} and <={MINIMUM_VALID_LONGTITUDE}. Given: {longtitude}");
        }

        if (_apiKey is null) throw new Exception("Missing api key.");

        var parameters = new List<(string, string)>(){
            (OpenWeatherParametersNames.Latitude, latitude.ToString()),
            (OpenWeatherParametersNames.Longitude, longtitude.ToString()),
            (OpenWeatherParametersNames.ApiKey, _apiKey)};

        var response = await _httpClient.GetAsync("data/2.5/weather", parameters);

        if (response.IsSuccessStatusCode)
        {
            var weatherForecast = await response.Content.Read<WeatherForecast>();
            if (weatherForecast is null) throw new Exception("Could not read weather forecast");
            return Result<WeatherForecast>.Success(weatherForecast);
        }

        return Result<WeatherForecast>.Failure("OpenWeatherMap api error: " + response.StatusCode.ToString());
    }

}

public class OpenWeatherParametersNames
{
    public const string Latitude = "lat";
    public const string Longitude = "lon";
    public const string ApiKey = "appid";
}