using Rooms.Api.Middlewares;

namespace Rooms.Api.Extensions;

public static class ApplicationBuilderExtension
{
    public static void UseGlobalExceptionMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }    
}