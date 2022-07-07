using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Core;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using System.Net;

namespace BusinessLayer.BusinessServices;
public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IUserRepository _userRepository;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IUserRepository userRepository)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _userRepository = userRepository;
    }

    public async Task<AuthenticateResponseDTO> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetUserByEmailAsync(email);
        if (user is null) throw new HttpResponseException(HttpStatusCode.BadRequest);
        
        var signInResult = await _userRepository.SignInUserByPasswordAsync(user, password);
        if (signInResult is null) throw new HttpResponseException(HttpStatusCode.InternalServerError, "Could not sign in user.");
        
        if (!signInResult.Succeeded) throw new HttpResponseException(HttpStatusCode.Unauthorized);
        return await AuthenticateAsync(user);
    }

    public async Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken)
    {       
        _refreshTokenService.Validate(requestRefreshToken);
        
        var refreshToken = await _refreshTokenService.GetRefreshTokenAsync(requestRefreshToken);
        await _refreshTokenService.RemoveRefreshTokenAsync(refreshToken);

        var user = await _userRepository.GetUserByIdAsync(refreshToken.UserId);

        return await AuthenticateAsync(user);
    }

    private async Task<AuthenticateResponseDTO> AuthenticateAsync(AppUser user)
        => new AuthenticateResponseDTO
        {
            AccessToken = await _accessTokenService.GenerateAsync(user),
            RefreshToken = await _refreshTokenService.GenerateAsync(user)
        };

}