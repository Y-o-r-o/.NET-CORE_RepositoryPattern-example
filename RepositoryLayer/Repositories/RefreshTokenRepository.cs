using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;

namespace RepositoryLayer.Repositories;
public class RefreshTokenRepository : IRefreshTokenRepository
{
    private DataContext _context;

    public RefreshTokenRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<RefreshToken> GetRefreshTokenByRequestRefreshToken(string requestRefreshToken)
    {
        return await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == requestRefreshToken);
    }

    public async Task RemoveRefreshToken(RefreshToken refreshToken)
    {
        _context.RefreshTokens.Remove(refreshToken);
        await _context.SaveChangesAsync();
    }

    public async Task AddRefreshToken(string refreshToken, string userId)
    {
        await _context.RefreshTokens.AddAsync(new RefreshToken()
        {
            UserId = userId,
            Token = refreshToken
        });
        await _context.SaveChangesAsync();
    }
}
