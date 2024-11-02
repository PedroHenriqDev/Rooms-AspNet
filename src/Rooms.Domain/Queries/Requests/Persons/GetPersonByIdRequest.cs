using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.Persons;

public class GetPersonByIdRequest : QueryRequest
{
    public GetPersonByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
