using BusinessLayer.DTOs;
using RepositoryLayer.Databases.Entities;
using System.Security.Claims;

namespace BusinessLayer.Interfaces;


public interface IAuthenticateService
{
    Task<AuthenticateResponseDTO> Authenticate(AppUser user);
}