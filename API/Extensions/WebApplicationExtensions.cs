using API.Middleware;

namespace API.Extensions;

public static class WebApplicationExtensions
{
    public static void Configure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.UseResponseInterceptor("(res) => console.log('test test test test test test')");
                swaggerUiOptions.UseRequestInterceptor("(req) => { req.headers['Authorization'] = 'Bearer ' + window?.swaggerUIRedirectOauth2?.auth?.token?.id_token; return req; }");
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }

}
