using System.Net;
using Rooms.App.Resources;

namespace Rooms.Api.Middlewares;

public class ExceptionMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError($"{ex.Message} - {ex.StackTrace}");

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            object response = new
            {
                Message = AppMessagesResource.INTERNAL_SERVER_ERROR
            }; 

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}