using Rooms.App.Dto;
using Rooms.Domain.Entities;

namespace Rooms.App.Mappings;
public static class MapperEntityToValue
{
    public static RoomTypeDto ToRoomTypeValue(this RoomType roomType)
    {
        return new RoomTypeDto(id: roomType.Id, name: roomType.Name);
    }
}