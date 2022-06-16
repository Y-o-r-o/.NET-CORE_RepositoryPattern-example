using RepositoryLayer.Mappers;
using ServiceClientLayer;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer()
                .AddSwaggerGen();

        services.Configure<OpenWeatherMapSettings>(config.GetSection("OpenWeatherMapSettings"));
        
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        
        services.AddRepositoryServices();
        services.AddServiceClientServices();



        return services;
    }
}
