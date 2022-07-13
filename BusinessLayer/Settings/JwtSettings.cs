using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Settings;

public class JwtSettings
{
    public string TokenKey { get; set; }
    public string RefreshTokenKey { get; set; }
    public double TokenValidityInMinutes { get; set; }
    public double RefreshTokenValidityInMinutes { get; set; }
    public TokenValidationParameters TokenValidationParameters { get; set; }
}