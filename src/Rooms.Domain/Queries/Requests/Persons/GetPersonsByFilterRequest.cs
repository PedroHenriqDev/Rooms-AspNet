using Rooms.Domain.Filters;
using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.Persons;

public sealed class GetPersonsByFilterRequest : QueryRequest
{
    public GetPersonsByFilterRequest(PersonFilter filter)
    {
        Filter = filter;
    }

    public PersonFilter Filter { get; set; }
}
