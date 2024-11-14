using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.IdentityModel.Tokens;
using Rooms.Api.Middlewares;
using System.Text;

namespace Rooms.Api.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddGlobalExceptionMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
    }

    public static void AddDefaultCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
             options.AddDefaultPolicy(policy =>
             {
                policy.AllowAnyHeader()
                      .AllowAnyOrigin()
                      .AllowAnyMethod()
                      .WithExposedHeaders("x-pagination");
             });
        });
    }

    public static void AddGzipResponseCompression(this IServiceCollection services)
    {
        services.AddResponseCompression(options => 
        {
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]{"application/json"});
            options.EnableForHttps = true;
        });
    }

    public static void AddAuthenticationBearer(this IServiceCollection services, IConfiguration configuration) 
    {
        string? key = configuration["Jwt:Key"] ?? throw new ArgumentNullException(nameof(key));

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.RequireHttpsMetadata = false;
            opt.SaveToken = true;
            opt.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
            };
        });
    }
}