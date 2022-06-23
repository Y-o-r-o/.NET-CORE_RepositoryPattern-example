using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

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
        if (!signInResult.Succeeded) throw new Exception("Login failure"); //TO DO: implement login exception.
        return await Authenticate(user);
    }

    public async Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken)
    {
        var isValidRefreshToken = _refreshTokenService.Validate(requestRefreshToken);
        if (!isValidRefreshToken)
            throw new Exception("Invalid refresh token."); //TO DO: implement bad token exception

        var refreshToken = await _refreshTokenService.GetRefreshToken(requestRefreshToken);
        await _refreshTokenService.RemoveRefreshToken(refreshToken);

        var user = await _userRepository.GetUserByIdAsync(refreshToken.UserId);

        return await Authenticate(user);
    }

    private async Task<AuthenticateResponseDTO> Authenticate(AppUser user)
    {
        return new AuthenticateResponseDTO
        {
            AccessToken = await _accessTokenService.Generate(user),
            RefreshToken = await _refreshTokenService.Generate(user)
        };
    }

}
