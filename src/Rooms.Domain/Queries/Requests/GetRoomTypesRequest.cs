using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests;

public sealed class GetRoomTypesRequest : RoomTypeQueryRequest
{
    public int Size {get; set;}
    public int OffSet {get; set;}

    public GetRoomTypesRequest(int size, int offSet)
    {
        Size = size;
        OffSet = offSet;
    }
}