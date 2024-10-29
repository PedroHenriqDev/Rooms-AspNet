using Rooms.Domain.Queries.Requests.Abstractions;

namespace Rooms.Domain.Queries.Requests.RoomTypes;

public sealed class GetRoomTypeByIdRequest : QueryRequest
{
    public GetRoomTypeByIdRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
