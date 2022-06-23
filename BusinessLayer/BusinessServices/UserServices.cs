using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;

namespace BusinessLayer.BusinessServices;

public class UserServices : IUserServices
{

    private readonly IUserRepository _userRepository;


    public UserServices(IUserRepository userRepository, IAuthenticateService authenticateService, IRefreshTokenService refreshTokenService, IRefreshTokenRepository refreshTokenRepository) 
    {
        _userRepository = userRepository;
    }


    public async Task<UserDTO> GetUserAsync(string id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return new UserDTO()
        {
            DisplayName = user.DisplayName,
            Bio = user.Bio
        };
    }

}