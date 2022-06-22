using BusinessLayer.DTOs;
using RepositoryLayer.Databases.Entities;
using System.Security.Claims;

namespace BusinessLayer.Interfaces;

public interface ITokenService
{
    public string Generate(AppUser user);
}

public interface IRefreshTokenService : ITokenService
{
    public bool Validate(string refreshToken);
}

public interface IAccessTokenService : ITokenService { }
