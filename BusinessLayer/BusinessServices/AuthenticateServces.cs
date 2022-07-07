using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using System.Net;
using System.Web.Http;

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
        var signInResult = await _userRepository.SignInUserByPasswordAsync(user, password);
        if (!signInResult.Succeeded) throw new HttpResponseException(HttpStatusCode.Unauthorized);
        return await Authenticate(user);
    }

    public async Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken)
    {
        _refreshTokenService.Validate(requestRefreshToken);
        
        var refreshToken = await _refreshTokenService.GetRefreshToken(requestRefreshToken);
        await _refreshTokenService.RemoveRefreshToken(refreshToken);

        var user = await _userRepository.GetUserByIdAsync(refreshToken.UserId);

        return await Authenticate(user);
    }

    private async Task<AuthenticateResponseDTO> Authenticate(AppUser user)
        => new AuthenticateResponseDTO
        {
            AccessToken = await _accessTokenService.Generate(user),
            RefreshToken = await _refreshTokenService.Generate(user)
        };

}