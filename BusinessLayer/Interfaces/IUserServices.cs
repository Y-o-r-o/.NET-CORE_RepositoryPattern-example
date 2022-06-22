using BusinessLayer.DTOs;
namespace BusinessLayer.BusinessServices;

public interface IUserServices
{
    public Task<UserDTO> GetUserAsync(string id);
    public Task<AuthenticateResponseDTO> LoginAsync(string email, string password);

    public Task<AuthenticateResponseDTO> RefreshTokenAsync(string requestRefreshToken);


}
