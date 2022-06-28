using BusinessLayer.BusinessServices;
using BusinessLayer.Interfaces;
using Core;
using System.IdentityModel.Tokens.Jwt;

namespace API.Extensions;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherServices, WeatherServices>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IUserServices, UserServices>();

        services.AddSingleton<JwtSecurityTokenHandler>();

        return services;
    }

}
