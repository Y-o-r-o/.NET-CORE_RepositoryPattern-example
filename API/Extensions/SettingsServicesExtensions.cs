using BusinessLayer.Settings;
using Microsoft.IdentityModel.Tokens;
using ServiceClientLayer;
using System.Text;

namespace API.Extensions;

public static class SettingsServicesExtensions
{
    public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind(nameof(JwtSettings), jwtSettings);
        jwtSettings.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = config.GetValue<bool>("JwtValidationSettings:ValidateIssuerSigningKey"),
            ValidateLifetime = config.GetValue<bool>("JwtValidationSettings:ValidateLifetime"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.RefreshTokenKey)),
            ValidateIssuer = config.GetValue<bool>("JwtValidationSettings:ValidateIssuer"),
            ValidateAudience = config.GetValue<bool>("JwtValidationSettings:ValidateAudience")
        };
        services.AddSingleton(jwtSettings);

        var openWeatherMapSettings = new OpenWeatherMapSettings();
        config.Bind(nameof(OpenWeatherMapSettings), openWeatherMapSettings);
        services.AddSingleton(openWeatherMapSettings);

        return services;
    }
}