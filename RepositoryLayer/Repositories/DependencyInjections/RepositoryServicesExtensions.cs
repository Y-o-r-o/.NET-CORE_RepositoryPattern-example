using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>()
            .AddScoped<IGeocodeRepository, GeocodeRepository>();

        return services;
    }
}