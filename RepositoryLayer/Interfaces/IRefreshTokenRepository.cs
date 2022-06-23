using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Repositories;
public interface IRefreshTokenRepository
{


    public Task<RefreshToken> GetRefreshTokenByRequestRefreshToken(string requestRefreshToken);
    public Task RemoveRefreshToken(RefreshToken refreshToken);
    public Task AddRefreshToken(string refreshToken, string userId);

}
