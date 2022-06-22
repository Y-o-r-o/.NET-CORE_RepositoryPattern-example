using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

public class UserServices : IUserServices
{

    private readonly IUserRepository _userRepository;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAuthenticateService _authenticateService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly DataContext _context;

    public UserServices(IUserRepository userRepository, SignInManager<AppUser> signInManager, IAuthenticateService authenticateService, IRefreshTokenService refreshTokenService, DataContext context) 
    {
        _userRepository = userRepository;
        _signInManager = signInManager;
        _authenticateService = authenticateService;
        _refreshTokenService = refreshTokenService;
        _context = context;
    }

    public async Task<UserDTO> GetUserAsync(string id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return new UserDTO()
        {
            DisplayName = user.DisplayName,
            Bio = user.Bio
        };
    }

    public async Task<AuthenticateResponseDTO> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null) throw new Exception("Bad credentials"); //TO DO: implement bad credentials exception.
        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if(!signInResult.Succeeded) throw new Exception("Login failure"); //TO DO: implement login exception.
        return await _authenticateService.Authenticate(user);
    }

    public async Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken)  
    {
        var isValidRefreshToken = _refreshTokenService.Validate(requestRefreshToken);
        if (!isValidRefreshToken)
            throw new Exception("Invalid refresh token."); //TO DO: implement bad token exception
        var refreshToken =
            await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == requestRefreshToken);
        if (refreshToken is null)
            throw new Exception("Invalid refresh token."); //TO DO: implement bad token exception

        _context.RefreshTokens.Remove(refreshToken);
        await _context.SaveChangesAsync();

        var user = await _userRepository.GetUserByIdAsync(refreshToken.UserId);
        if (user is null) throw new Exception("Bad credentials"); //TO DO: implement bad credentials exception.

        return await _authenticateService.Authenticate(user);
    }



}
