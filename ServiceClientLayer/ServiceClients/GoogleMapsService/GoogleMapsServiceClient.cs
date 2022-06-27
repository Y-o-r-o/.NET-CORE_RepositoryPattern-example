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

    public async Task<Result<Geocode>> GetCordinates(string city)
    {
        var parameters = new List<(string, string)>(){
            ("address", city),
            ("key", _googleMapsSettings.ApiKey)};

        var response = await _httpClient.GetAsync($"maps/api/geocode/{_googleMapsSettings.OutputFormat}", parameters);

        if (response.IsSuccessStatusCode)
        {
            var geocode = await response.Content.Read<Geocode>();
            return Result<Geocode>.Success(geocode);
        }

        return Result<Geocode>.Failure("GoogleMaps api error: " + response.StatusCode.ToString());
    }

}