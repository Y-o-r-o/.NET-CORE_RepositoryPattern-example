using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;
public interface IGeocodeRepository
{
    public Task<Geocode?> GetGeocodeByCityName(string city);

}
