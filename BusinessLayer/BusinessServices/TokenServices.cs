using BusinessLayer.Interfaces;
using BusinessLayer.Settings;
using Core;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLayer.DTOs;

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

    public string Generate(AppUser user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        return _tokenGenerator.Generate(_jwtSettings.TokenKey, _jwtSettings.TokenValidityInMinutes, claims);
    }
}

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings)
    {
        _tokenGenerator = tokenGenerator;
        _jwtSettings = jwtSettings;
    }

    public string Generate(AppUser user)
    {
        return _tokenGenerator.Generate(_jwtSettings.TokenKey, _jwtSettings.RefreshTokenValidityInMinutes);
    }

    public bool Validate(string refreshToken)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.RefreshTokenKey)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        try
        {
            jwtSecurityTokenHandler.ValidateToken(refreshToken, validationParameters,
                out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

