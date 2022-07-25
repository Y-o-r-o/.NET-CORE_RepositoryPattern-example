using BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Repositories.DependencyInjections;

namespace BusinessLayer.BusinessServices.DependencyInjections;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddRepositoryServices(config);

        services.AddIdentityServices();

        services.AddScoped<IWeatherServices, WeatherServices>()
            .AddScoped<IRefreshTokenService, RefreshTokenService>()
            .AddScoped<IAccessTokenService, AccessTokenService>()
            .AddScoped<IAuthenticateService, AuthenticateService>()
            .AddScoped<IUserServices, UserServices>();

        return services;
    }
}