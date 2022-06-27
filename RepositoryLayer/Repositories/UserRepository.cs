using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;


    public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    public async Task<AppUser> GetUserByIdAsync(string id)
    {
        var user = HandleUserResult(await _userManager.FindByIdAsync(id));
        return user;
    }

    public async Task<AppUser> GetUserByEmailAsync(string email)
    {
        var user = HandleUserResult(await _userManager.FindByEmailAsync(email));
        return user;
    }

    public async Task<SignInResult> SignInUserByPasswordAsync(AppUser user, string password)
    {
        return await _signInManager.CheckPasswordSignInAsync(user, password, false);
    }


    private AppUser HandleUserResult(AppUser user) 
    {
        if (user is null) throw new Exception("Bad credentials"); //TO DO: implement bad credentials exception.
        return user;
    }

}
