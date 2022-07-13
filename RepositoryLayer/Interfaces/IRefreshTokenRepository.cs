using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Repositories;

public interface IRefreshTokenRepository
{
    public Task<RefreshToken?> GetRefreshTokenByRequestRefreshTokenAsync(string requestRefreshToken);

    public Task RemoveRefreshTokenAsync(RefreshToken refreshToken);

    public Task AddRefreshTokenAsync(string refreshToken, string userId);
}