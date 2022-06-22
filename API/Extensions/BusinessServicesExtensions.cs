using BusinessLayer.BusinessServices;
using BusinessLayer.Interfaces;
using Core;

namespace API.Extensions;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherServices, WeatherServices>();
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IUserServices, UserServices>();

        return services;
    }

}
