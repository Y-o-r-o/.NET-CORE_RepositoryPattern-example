
using API.Extensions;

namespace API;

internal class Program
{

    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddApplicationServices();

        var app = builder.Build();
        app.ConfigurHttpRequestPipeline();

        app.Run();
    }
}