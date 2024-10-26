using System.Net;

namespace Rooms.Domain.Responses.Interfaces;

public interface IResponse
{
    bool Success {get; set;}
    string Message {get; set;}
    HttpStatusCode StatusCode {get; set;}
    object? Value {get; set;}
}