using RepositoryLayer.Interfaces;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories.Base;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace RepositoryLayer.Repositories;
internal class LocationRepository : ServiceClientRepositoryBase<Location>, ILocationRepository
{

    private IGoogleMapsServiceClient _googleMapsServiceClient;

    public LocationRepository(IGoogleMapsServiceClient googleMapsServiceClient, IServiceProvider service) : base(service)
    {
        _googleMapsServiceClient = googleMapsServiceClient;
    }

    public async Task<Location?> GetLocationByCityName(string city)
        => await GetAsync(_googleMapsServiceClient.GetCordinates, city);



    //Old
    //public async Task<Location> GetLocationByCityName(string city)
    //{
    //    var googleMapsResponse = await _googleMapsServiceClient.GetCordinates(city);
    //    Location location = null;
    //    if (googleMapsResponse.IsSuccess)
    //    {
    //        location = MappingProfiles.Map(googleMapsResponse.Value).Results[0].Geometry.Location;
    //    }
    //    return location;
    //}

}