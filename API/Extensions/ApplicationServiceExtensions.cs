using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases.Configuration;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.ConfigureSettings(config);
        services.AddControllers();

        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("Context")));

        // Learn more about configuzring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

        services.AddServiceClientServices();
        services.AddRepositoryServices();
        services.AddBusinessServices();

        services.AddIdentityServices(config);

        return services;
    }
}