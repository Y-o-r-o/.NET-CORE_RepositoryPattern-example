using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Interfaces;

public interface IUserRepository
{
    public Task<AppUser> GetUserByIdAsync(string id);

    public Task<AppUser> GetUserByEmailAsync(string email);

}
