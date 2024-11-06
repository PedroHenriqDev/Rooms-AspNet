using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Commands.Requests.Persons;

public sealed class DeletePersonRequest : QueryRequest
{
    public DeletePersonRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
