using Rooms.Domain.Filters;
using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.RoomTypes;

public sealed class GetRoomTypesByFilterRequest : QueryRequest
{
    public GetRoomTypesByFilterRequest(RoomTypeFilter filter)
    {
        Filter = filter;
    }

    public RoomTypeFilter Filter { get; set; }
}
