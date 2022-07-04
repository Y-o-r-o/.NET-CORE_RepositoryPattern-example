using RepositoryLayer.Models;

namespace RepositoryLayer.Interfaces;
public interface IGoogleMapsRepository
{
    public Task<Location> GetCordinates(string city);

}
