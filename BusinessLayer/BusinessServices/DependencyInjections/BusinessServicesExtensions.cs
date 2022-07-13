using BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.BusinessServices.DependencyInjections;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddIdentityServices();

        services.AddScoped<IWeatherServices, WeatherServices>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IUserServices, UserServices>();

        return services;
    }
}