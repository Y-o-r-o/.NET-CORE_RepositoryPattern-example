using Core;
using ServiceClientLayer.Models;
using ServiceClientLayer.Extensions;
using ServiceClientLayer.ServiceClients.GoogleMapsService;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public class GoogleMapsServiceClient : IGoogleMapsServiceClient
{
    private GoogleMapsSettings _googleMapsSettings;
    private HttpClient _httpClient;

    public GoogleMapsServiceClient(HttpClient httpClient, GoogleMapsSettings googleMapsSettings)
    {
        _googleMapsSettings = googleMapsSettings;
        _httpClient = httpClient;
    }

    public async Task<Result<Geocode>> GetCordinatesAsync(string city)
    {
        if (_googleMapsSettings.ApiKey is null) throw new Exception("Missing api key.");
        if (_googleMapsSettings.OutputFormat is null) throw new Exception("Missing output format.");

        var parameters = new List<(string, string)>(){
            (GoogleMapsParametersNames.Address, city),
            (GoogleMapsParametersNames.ApiKey, _googleMapsSettings.ApiKey)};

        var response = await _httpClient.GetAsync($"maps/api/geocode/{_googleMapsSettings.OutputFormat}", parameters);

        if (response.IsSuccessStatusCode)
        {
            var geocode = await response.Content.Read<Geocode>();
            if (geocode is null) throw new Exception("Could not read geocode.");
            return Result<Geocode>.Success(geocode);
        }

        return Result<Geocode>.Failure("GoogleMaps api error: " + response.StatusCode.ToString());
    }

}

public class GoogleMapsParametersNames
{
    public const string Address = "address";
    public const string ApiKey = "key";
}