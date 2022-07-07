using Core.Mappings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions;

public static class JwtSecurityTokenHandlerExtensions
{
    public static void ValidateToken(this JwtSecurityTokenHandler handler, string refreshToken, TokenValidationParameters validationParameters)
    {
        try
        {
            handler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
        }
        catch (ArgumentNullException ex) 
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception ex)
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized, ex.Message);
        }
    }

    public static string GenerateToken(this JwtSecurityTokenHandler handler, string secretKey, double expires, IEnumerable<Claim>? claims = null)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        SecurityTokenDescriptor tokenDescriptor = MappingProfiles.Map(claims, expires, credentials);
        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

}