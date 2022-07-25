using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using System.Security.Claims;

namespace BusinessLayer.Interfaces;

public interface ITokenService
{
    public string Generate(string secretKey, double expires, IEnumerable<Claim>? claims);

    public void Validate(string token, TokenValidationParameters validationParameters);

    public Task<string> GenerateAsync(AppUser user);
}

public interface IRefreshTokenService : ITokenService
{
    public void Validate(string refreshToken);

    public Task<RefreshToken> GetRefreshTokenAsync(string requestRefreshToken);

    public Task RemoveRefreshTokenAsync(RefreshToken refreshToken);
}

public interface IAccessTokenService : ITokenService
{ }