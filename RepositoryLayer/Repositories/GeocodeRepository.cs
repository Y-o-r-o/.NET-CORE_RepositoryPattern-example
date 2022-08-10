using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories.Base;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace RepositoryLayer.Repositories;

internal class GeocodeRepository : ServiceClientRepositoryBase<Geocode>, IGeocodeRepository
{
    private IGoogleMapsServiceClient _googleMapsServiceClient;

    public GeocodeRepository(IGoogleMapsServiceClient googleMapsServiceClient, CacheFactory cacheFactory) : base(cacheFactory)
    {
        _googleMapsServiceClient = googleMapsServiceClient;
    }

    public async Task<Geocode?> GetGeocodeByCityNameAsync(string city)
        => await GetAsync(() => _googleMapsServiceClient.GetCordinatesAsync(city));

}