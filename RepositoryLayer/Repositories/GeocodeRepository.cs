using RepositoryLayer.Interfaces;
using RepositoryLayer.Mappers;
using RepositoryLayer.Models;
using RepositoryLayer.Repositories.Base;
using ServiceClientLayer.ServiceClients.OpenWeatherService;

namespace RepositoryLayer.Repositories;
internal class GeocodeRepository : ServiceClientRepositoryBase<Geocode>, IGeocodeRepository
{

    private IGoogleMapsServiceClient _googleMapsServiceClient;

    public GeocodeRepository(IGoogleMapsServiceClient googleMapsServiceClient)
    {
        _googleMapsServiceClient = googleMapsServiceClient;
    }

    public async Task<Geocode?> GetGeocodeByCityName(string city)
        => await GetAsync(_googleMapsServiceClient.GetCordinates, city);





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