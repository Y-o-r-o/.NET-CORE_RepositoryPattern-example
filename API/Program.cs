
using API.Extensions;

namespace API;

internal class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.ConfigureServices();

        var app = builder.Build();
        app.Configure();

        app.Run();
    }
}