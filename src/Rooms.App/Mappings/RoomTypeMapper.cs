using Rooms.App.Dto;
using Rooms.Domain.Entities;

namespace Rooms.App.Mappings;

public static class RoomTypeMapper
{
    public static RoomTypeDto ToRoomTypeDto(this RoomType roomType)
    {
        return new RoomTypeDto(id: roomType.Id, name: roomType.Name, createdAt: roomType.CreatedAt);
    }
}
