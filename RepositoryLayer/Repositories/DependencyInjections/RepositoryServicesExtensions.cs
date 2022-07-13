using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Interfaces;
using RepositoryLayer.RepositoryServices;

namespace RepositoryLayer.Repositories.DependencyInjections;

public static class RepositoryServicesExtensions
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("Context")));

        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IGeocodeRepository, GeocodeRepository>();

        return services;
    }
}