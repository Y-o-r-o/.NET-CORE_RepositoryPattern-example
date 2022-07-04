using BusinessLayer.Settings;
using Microsoft.IdentityModel.Tokens;
using ServiceClientLayer;
using ServiceClientLayer.ServiceClients.GoogleMapsService;
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
            ValidateIssuerSigningKey = config.GetValue<bool>("JwtSettings:JwtValidationSettings:ValidateIssuerSigningKey"),
            ValidateLifetime = config.GetValue<bool>("JwtSettings:JwtValidationSettings:ValidateLifetime"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.RefreshTokenKey)),
            ValidateIssuer = config.GetValue<bool>("JwtSettings:JwtValidationSettings:ValidateIssuer"),
            ValidateAudience = config.GetValue<bool>("JwtSettings:JwtValidationSettings:ValidateAudience")
        };
        services.AddSingleton(jwtSettings);

        var openWeatherMapSettings = new OpenWeatherMapSettings();
        config.Bind(nameof(OpenWeatherMapSettings), openWeatherMapSettings);
        services.AddSingleton(openWeatherMapSettings); 
        
        var googleMapsSettings = new GoogleMapsSettings();
        config.Bind(nameof(GoogleMapsSettings), googleMapsSettings);
        services.AddSingleton(googleMapsSettings);

        return services;
    }
}