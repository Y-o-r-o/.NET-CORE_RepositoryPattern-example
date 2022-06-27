using Core;
using ServiceClientLayer.Models;

namespace ServiceClientLayer.ServiceClients.OpenWeatherService;

public interface IGoogleMapsServiceClient
{

    public Task<Result<Geocode>> GetCordinates(string city);

}