using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Interfaces;

public interface IUserRepository
{
    public Task<AppUser?> GetUserByIdAsync(string id);

    public Task<AppUser?> GetUserByEmailAsync(string email);

    public Task<IEnumerable<AppUser>?> GetUsersAsync();
    
    public Task<SignInResult?> SignInUserByPasswordAsync(AppUser user, string password);

}
