using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Mappers;
using RepositoryLayer.Models;
using RepositoryLayer.RepositoryServices;

namespace RepositoryLayer.Repositories.DependencyInjections;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddScoped<IMainForecastRepository, MainForecastRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        
        services.AddSingleton<IMapper<ServiceClientLayer.Models.Geocode, Geocode>, GeocodeMapper>();
        return services;
    }

}