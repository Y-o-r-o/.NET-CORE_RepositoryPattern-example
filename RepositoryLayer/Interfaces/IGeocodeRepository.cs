using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;
public interface IGeocodeRepository
{
    public Task<Geocode?> GetGeocodeByCityNameAsync(string city);

}
