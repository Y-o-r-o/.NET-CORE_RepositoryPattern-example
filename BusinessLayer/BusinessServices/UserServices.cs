using BusinessLayer.BusinessServices.Base;
using BusinessLayer.DTOs;
using BusinessLayer.Mappers;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;

namespace BusinessLayer.BusinessServices;

internal class UserServices : RepositoryBusinessBase, IUserServices
{
    private readonly IUserRepository _userRepository;

    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDTO> GetUserAsync(string id)
        => MappingProfiles.Map(await GetAsync(_userRepository.GetUserByIdAsync, id));

    public async Task<IEnumerable<UserDTO>> GetUsersAsync()
    {
        var users = await GetAllAsync(_userRepository.GetUsersAsync);
        List<UserDTO> mapped = new();
        foreach (AppUser user in users)
        {
            mapped.Add(MappingProfiles.Map(user));
        }
        return mapped;
    }
}