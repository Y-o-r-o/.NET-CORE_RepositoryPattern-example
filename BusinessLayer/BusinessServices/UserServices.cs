using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using BusinessLayer.Mappers;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;

namespace BusinessLayer.BusinessServices;

public class UserServices : IUserServices
{

    private readonly IUserRepository _userRepository;


    public UserServices(IUserRepository userRepository) 
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

    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        List<UserDTO> mapped = new();
        foreach (AppUser user in users)
        {
            mapped.Add(MappingProfiles.Map(user));
        }
        return mapped;
    }



}