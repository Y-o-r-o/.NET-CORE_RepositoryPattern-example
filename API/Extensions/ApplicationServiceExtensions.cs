using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
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


        services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("Context")));
        services.AddIdentityCore<AppUser>().AddEntityFrameworkStores<DataContext>();

        services.Configure<OpenWeatherMapSettings>(config.GetSection("OpenWeatherMapSettings"));

        services.AddServiceClientServices();
        services.AddRepositoryServices();
        services.AddBusinessServices();


        return services;
    }
}