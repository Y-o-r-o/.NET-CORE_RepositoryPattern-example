using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories.Base;

namespace RepositoryLayer.Repositories;

internal class UserRepository : ContextRepositoryBase<AppUser>, IUserRepository
{
    private readonly SignInManager<AppUser> _signInManager;

    public UserRepository(DataContext context, SignInManager<AppUser> signInManager, CacheFactory cacheFactory) : base(context, cacheFactory)
    {
        _signInManager = signInManager;
    }

    public async Task<AppUser?> GetUserByIdAsync(string id)
        => await GetAsync(u => u.Id == id);

    public async Task<AppUser?> GetUserByEmailAsync(string email)
        => await GetAsync(u => u.Email == email);

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
        => await GetAllAsync();

    public async Task<SignInResult?> SignInUserByPasswordAsync(AppUser user, string password)
    {
        var res = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        await _context.SaveChangesAsync();
        return res;
    }
}