using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.Users;

public sealed class GetUserByEmailRequest : QueryRequest
{
    public GetUserByEmailRequest(string email)
    {
        Email = email;
    }

    public string Email { get; set; }  
}
