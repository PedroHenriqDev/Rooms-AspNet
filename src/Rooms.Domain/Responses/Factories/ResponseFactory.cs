using Rooms.Domain.Responses;
using System.Net;

namespace Rooms.Domain.Responses.Factories;

public static class ResponseFactory
{
    public static Response Success(string message, object value = null!)
    {
        return new Response
        (
            message: message,
            value: value,
            statusCode: HttpStatusCode.OK
        );
    }

    public static Response NotFound(object value, string message = null!)
    {
        if (message is null)
        {
            message = ResponseResource.NOT_FOUND_MESSAGE;
        }

        return new Response
        (
           message: message,
           value: value,
           statusCode: HttpStatusCode.OK,
           success: false
        );
    }

    public static Response BadRequest(object value, string message = null!)
    {
        if (message is null)
        {
            message = ResponseResource.BAD_REQUEST_MESSAGE;
        }

        return new Response
        (
           message: message,
           value: value,
           statusCode: HttpStatusCode.OK,
           success: false
        );
    }
}
