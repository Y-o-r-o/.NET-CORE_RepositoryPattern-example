using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Core.Extensions;

public static class JwtSecurityTokenHandlerExtensions
{
    public static bool ValidateToken(this JwtSecurityTokenHandler handler, string refreshToken, TokenValidationParameters validationParameters)
    {
        try
        {
            handler.ValidateToken(refreshToken, validationParameters, out SecurityToken validatedToken);
            return true;
        }
        catch (Exception)
        {
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }

}