using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests;

public sealed class GetRoomTypeByIdRequest : RoomTypeQueryRequest
{
    public GetRoomTypeByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
