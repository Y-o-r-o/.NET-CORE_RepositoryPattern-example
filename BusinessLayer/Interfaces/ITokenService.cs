using RepositoryLayer.Databases.Entities;

namespace BusinessLayer.Interfaces;

public interface ITokenService
{
    public Task<string> Generate(AppUser user);
}

public interface IRefreshTokenService : ITokenService
{
    public bool Validate(string refreshToken);
    public Task<RefreshToken> GetRefreshToken(string requestRefreshToken);
    public Task RemoveRefreshToken(RefreshToken refreshToken);
}

public interface IAccessTokenService : ITokenService { }
