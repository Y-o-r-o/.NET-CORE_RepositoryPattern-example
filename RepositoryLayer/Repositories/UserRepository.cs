using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories.Base;

namespace RepositoryLayer.Repositories;

internal class UserRepository : ContextRepositoryBase<AppUser>, IUserRepository
{
    private readonly SignInManager<AppUser> _signInManager;

    public UserRepository(DataContext context, SignInManager<AppUser> signInManager) : base(context)
    {
        _signInManager = signInManager;

        Entities = context.Set<AppUser>();
    }

    public async Task<AppUser?> GetUserByIdAsync(string id)
        => await GetAsync(u => u.Id == id);

    public async Task<AppUser?> GetUserByEmailAsync(string email)
        => await GetAsync(u => u.Email == email);

    public async Task<SignInResult?> SignInUserByPasswordAsync(AppUser user, string password)
        => await _signInManager.CheckPasswordSignInAsync(user, password, false);

}