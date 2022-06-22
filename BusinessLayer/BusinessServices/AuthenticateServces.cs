using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;

namespace BusinessLayer.BusinessServices;
public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly DataContext _context;

    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, DataContext context)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _context = context;
    }

    public async Task<AuthenticateResponseDTO> Authenticate(AppUser user)
    {
        var refreshToken = _refreshTokenService.Generate(user);
        await _context.RefreshTokens.AddAsync(new RefreshToken()
        {
            UserId = user.Id,
            Token = refreshToken
        });
        await _context.SaveChangesAsync();
        return new AuthenticateResponseDTO
        {
            AccessToken = _accessTokenService.Generate(user),
            RefreshToken = refreshToken
        };
    }
}
