using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Core.Mappings;

public static class MappingProfiles
{
    public static SecurityTokenDescriptor Map(IEnumerable<Claim> claims, double expires, SigningCredentials credentials)
    {
        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expires),
            SigningCredentials = credentials
        };
    }
}
