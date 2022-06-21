using API.Extensions;
using Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API;

internal class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices(builder.Configuration);


        var app = builder.Build();

        using var scope = app.Services.CreateScope();
        var servicesProvider = scope.ServiceProvider;

        try
        {
            var context = servicesProvider.GetRequiredService<DataContext>();
            var userManager = servicesProvider.GetRequiredService<UserManager<AppUser>>();
            await context.Database.MigrateAsync();
            await Seed.SeedData(context, userManager);
        }
        catch (Exception ex)
        {
            var logger = servicesProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration");
        }

        app.Configure();

        app.Run();
    }
}