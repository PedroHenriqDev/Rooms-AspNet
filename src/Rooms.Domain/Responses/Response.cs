using System.Net;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Responses;

public class Response : IResponse
{
    public Response(string message, HttpStatusCode statusCode, object value, bool success = true)
    {
        Message = message;
        StatusCode = statusCode;
        Value = value;
        Success = success;
    }

    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode StatusCode { get; set; }
    public object? Value { get;set; }
}