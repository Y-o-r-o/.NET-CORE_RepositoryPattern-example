using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;
public interface ILocationRepository
{
    public Task<Location> GetLocationByCityName(string city);

}
