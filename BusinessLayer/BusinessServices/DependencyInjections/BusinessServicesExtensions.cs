using BusinessLayer.Interfaces;
using BusinessLayer.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BusinessLayer.BusinessServices.DependencyInjections;

public static class BusinessServicesExtensions
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IWeatherServices, WeatherServices>();
        services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        services.AddScoped<IAccessTokenService, AccessTokenService>();
        services.AddScoped<IAuthenticateService, AuthenticateService>();
        services.AddScoped<IUserServices, UserServices>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            var jwtSettings = services.BuildServiceProvider().GetService<JwtSettings>()!;
            x.SaveToken = true;
            x.RequireHttpsMetadata = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.TokenKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        });
        services.AddSingleton<JwtSecurityTokenHandler>();

        return services;
    }

}
