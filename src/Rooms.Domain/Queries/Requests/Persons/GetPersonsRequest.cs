using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.Persons;

public sealed class GetPersonsRequest : QueryRequest
{
    public GetPersonsRequest(int size, int offSet)
    {
        Size = size;
        OffSet = offSet;
    }

    public int Size { get; set; }
    public int OffSet { get; set; }
}
