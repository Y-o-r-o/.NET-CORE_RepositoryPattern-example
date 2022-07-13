using RepositoryLayer.Databases.Entities;

namespace BusinessLayer.Interfaces;

public interface ITokenService
{
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