using BusinessLayer.Interfaces;
using BusinessLayer.Settings;
using Core;
using RepositoryLayer.Databases.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RepositoryLayer.Repositories;
using Core.Extensions;

namespace BusinessLayer.BusinessServices;



public class AccessTokenService : IAccessTokenService
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(JwtSettings jwtSettings, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _jwtSettings = jwtSettings;
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public Task<string> Generate(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        return Task.FromResult(_jwtSecurityTokenHandler.GenerateToken(_jwtSettings.TokenKey, _jwtSettings.TokenValidityInMinutes, claims));
    }
}


public class RefreshTokenService : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings;
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public async Task<string> Generate(AppUser user)
    {
        var refreshToken = _jwtSecurityTokenHandler.GenerateToken(_jwtSettings.RefreshTokenKey, _jwtSettings.RefreshTokenValidityInMinutes);
        await _refreshTokenRepository.AddRefreshToken(refreshToken, user.Id);
        return refreshToken;
    }

    public async Task<RefreshToken> GetRefreshToken(string requestRefreshToken)
    {
        return await _refreshTokenRepository.GetRefreshTokenByRequestRefreshToken(requestRefreshToken);
    }

    public async Task RemoveRefreshToken(RefreshToken refreshToken)
    {
        await _refreshTokenRepository.RemoveRefreshToken(refreshToken);
    }

    public void Validate(string refreshToken)
    {
        _jwtSecurityTokenHandler.ValidateToken(refreshToken, _jwtSettings.TokenValidationParameters);
    }

}