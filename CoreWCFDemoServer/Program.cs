using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCFDemoServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.AllowSynchronousIO = true;
});

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();

var app = builder.Build();
app.UseServiceModel(builder =>
{
    builder.AddService<EchoService>()
    // Add a BasicHttpBinding at a specific endpoint
    .AddServiceEndpoint<EchoService, IEchoService>(new BasicHttpBinding(), "/EchoService/basichttp");
    // // Add a WSHttpBinding with Transport Security for TLS
    // .AddServiceEndpoint<EchoService, IEchoService>(new WSHttpBinding(SecurityMode.Transport), "/EchoService/WSHttps");
});

var serviceMetadataBehavior = (ServiceMetadataBehavior)app.Services.GetRequiredService(typeof(ServiceMetadataBehavior));
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();