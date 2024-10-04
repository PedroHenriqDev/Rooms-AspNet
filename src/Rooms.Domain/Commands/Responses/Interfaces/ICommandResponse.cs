using System.Net;

namespace Rooms.Domain.Commands.Responses.Interfaces;

public interface ICommandResponse
{
        
    bool Success {get; set;}
    string Message {get; set;}
    HttpStatusCode StatusCode {get; set;}
    object? Value {get; set;}
}