using BusinessLayer.DTOs;
namespace BusinessLayer.BusinessServices;

public interface IUserServices
{
    public Task<UserDTO> GetUserAsync(string id);
    public Task<IEnumerable<UserDTO>> GetUsersAsync();

}
