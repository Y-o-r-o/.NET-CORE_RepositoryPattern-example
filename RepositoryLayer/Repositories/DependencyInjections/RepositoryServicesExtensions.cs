using EasyCaching.Core.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Databases.Cache;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.DependencyInjections;

namespace RepositoryLayer.Repositories.DependencyInjections;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddServiceClientServices();
        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("Context")));

        services.AddStackExchangeRedisCache(options => options.Configuration = config.GetConnectionString("RedisCache"));
        services.AddMemoryCache();
        services.AddScoped<DistributedCache>();
        services.AddScoped<MemoryCache>();
        services.AddScoped<CacheFactory>();

        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
            .AddScoped<IGeocodeRepository, GeocodeRepository>();

        return services;
    }
}