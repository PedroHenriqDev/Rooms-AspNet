using Microsoft.AspNetCore.ResponseCompression;
using Rooms.Api.Middlewares;

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
}