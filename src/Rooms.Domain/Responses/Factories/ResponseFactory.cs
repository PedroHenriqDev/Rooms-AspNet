using Rooms.Domain.Responses;
using System.Net;

namespace Rooms.Domain.Responses.Factories;

public static class ResponseFactory
{
    public static Response Success(object value, string message = null!)
    {
        if(message == null) 
        {
            message = ResponseResource.SUCCESSFUL_REQUEST_MESSAGE;
        }

        return new Response
        (
            message: message,
            value: value,
            statusCode: HttpStatusCode.OK
        );
    }

    public static Response Created(object value, string message = null!)
    {
        if (message == null)
        {
            message = ResponseResource.SUCCESSFUL_REQUEST_MESSAGE;
        }

        return new Response
        (
            message: message,
            value: value,
            statusCode: HttpStatusCode.Created
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
           statusCode: HttpStatusCode.NotFound,
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
           statusCode: HttpStatusCode.BadRequest,
           success: false
        );
    }
}
