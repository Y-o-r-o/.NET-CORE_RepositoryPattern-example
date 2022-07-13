using BusinessLayer.DTOs;

namespace BusinessLayer.Interfaces;

public interface IAuthenticateService
{
    public Task<AuthenticateResponseDTO> LoginAsync(string email, string password);

    public Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken);
}