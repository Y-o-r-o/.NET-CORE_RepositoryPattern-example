using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Databases;
using RepositoryLayer.Databases.Configuration;
using RepositoryLayer.Databases.Entities;

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

        var context = servicesProvider.GetRequiredService<DataContext>();
        var userManager = servicesProvider.GetRequiredService<UserManager<AppUser>>();
        await context.Database.MigrateAsync();
        await Seed.SeedData(context, userManager);


        app.Configure();

        app.Run();
    }
}