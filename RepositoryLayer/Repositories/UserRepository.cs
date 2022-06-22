using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;

    public UserRepository(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AppUser> GetUserByIdAsync(string id)
    {
       return await _userManager.FindByIdAsync(id);
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }
}
