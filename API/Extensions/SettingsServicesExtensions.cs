using BusinessLayer.Settings;
using ServiceClientLayer;

namespace API.Extensions;

public static class SettingsServicesExtensions
{
    public static IServiceCollection ConfigureSettings(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(jwtSettings);


        var openWeatherMapSettings = new OpenWeatherMapSettings();
        config.Bind(nameof(OpenWeatherMapSettings), openWeatherMapSettings);
        services.AddSingleton(openWeatherMapSettings);

        return services;
    }
}