using BusinessLayer.Interfaces;
using BusinessLayer.Settings;
using Core;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using RepositoryLayer.Repositories;
using Core.Extensions;

namespace BusinessLayer.BusinessServices;



public class AccessTokenService : IAccessTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
    {
        _tokenGenerator = tokenGenerator;
        _jwtSettings = jwtSettings;
    }

    public Task<string> Generate(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        return Task.FromResult(_tokenGenerator.Generate(_jwtSettings.TokenKey, _jwtSettings.TokenValidityInMinutes, claims));
    }
}

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings, IRefreshTokenRepository refreshTokenRepository)
    {
        _tokenGenerator = tokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
        _jwtSettings = jwtSettings;
    }

    public async Task<string> Generate(AppUser user)
    {
        var refreshToken = _tokenGenerator.Generate(_jwtSettings.RefreshTokenKey, _jwtSettings.RefreshTokenValidityInMinutes);
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

    public bool Validate(string refreshToken)
    {
        return new JwtSecurityTokenHandler().ValidateToken(refreshToken, _jwtSettings.TokenValidationParameters);
    }
}

