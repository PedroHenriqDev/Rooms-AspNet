using System.Net;
using Rooms.Domain.Commands.Responses.Interfaces;

namespace Rooms.Domain.Commands.Responses;

public class CommandResponse : ICommandResponse
{
    public bool Success {get; set;}
    public string Message {get; set;} = string.Empty;
    public HttpStatusCode StatusCode {get; set;} = HttpStatusCode.OK;
    public object? Value {get; set;}

    public CommandResponse(string message, HttpStatusCode statusCode, object value, bool success = true)
    {
        Success = success;
        Message = message;
        StatusCode = statusCode;
        Value = value;
    }
}