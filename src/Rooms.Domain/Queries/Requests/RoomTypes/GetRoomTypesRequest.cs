using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.RoomTypes;

public sealed class GetRoomTypesRequest : QueryRequest
{
    public GetRoomTypesRequest(int size, int offSet)
    {
        Size = size;
        OffSet = offSet;
    }

    public int Size {get; set;}
    public int OffSet {get; set;}
}