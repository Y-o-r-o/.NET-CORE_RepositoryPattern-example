using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Repositories.Base;

namespace RepositoryLayer.Repositories;

internal class RefreshTokenRepository : ContextRepositoryBase<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(DataContext context) : base(context)
    {
        Entities = context.Set<RefreshToken>();
    }

    public async Task<RefreshToken?> GetRefreshTokenByRequestRefreshTokenAsync(string requestRefreshToken)
        => await GetAsync(t => t.Token == requestRefreshToken);

    public async Task RemoveRefreshTokenAsync(RefreshToken refreshToken)
        => await RemoveAsync(refreshToken);

    public async Task AddRefreshTokenAsync(string refreshToken, string userId)
        => await AddAsync(new RefreshToken() { UserId = userId, Token = refreshToken });
}