using BusinessLayer.Interfaces;
using BusinessLayer.Settings;
using RepositoryLayer.Databases.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using RepositoryLayer.Repositories;
using Core.Extensions;
using BusinessLayer.BusinessServices.Base;

namespace BusinessLayer.BusinessServices;



internal class AccessTokenService : IAccessTokenService
{
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(JwtSettings jwtSettings, JwtSecurityTokenHandler jwtSecurityTokenHandler)
    {
        _jwtSettings = jwtSettings;
        _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
    }

    public Task<string> GenerateAsync(AppUser user)
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


internal class RefreshTokenService : RepositoryBusinessBase, IRefreshTokenService
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

    public async Task<string> GenerateAsync(AppUser user)
    {
        var refreshToken = _jwtSecurityTokenHandler.GenerateToken(_jwtSettings.RefreshTokenKey, _jwtSettings.RefreshTokenValidityInMinutes);
        await _refreshTokenRepository.AddRefreshTokenAsync(refreshToken, user.Id);
        return refreshToken;
    }

    public async Task<RefreshToken> GetRefreshTokenAsync(string requestRefreshToken)
        => await GetAsync(_refreshTokenRepository.GetRefreshTokenByRequestRefreshTokenAsync, requestRefreshToken);

    public async Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
        =>  await _refreshTokenRepository.RemoveRefreshTokenAsync(refreshToken);
    

    public void Validate(string refreshToken)
        => _jwtSecurityTokenHandler.ValidateToken(refreshToken, _jwtSettings.TokenValidationParameters);


}