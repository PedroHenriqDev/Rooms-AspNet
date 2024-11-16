using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.Users;

public sealed class GetUserByNameRequest : QueryRequest
{
    public GetUserByNameRequest(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
