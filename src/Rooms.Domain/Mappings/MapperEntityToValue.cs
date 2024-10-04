using System.Reflection.Metadata.Ecma335;
using Rooms.Domain.Commands.Responses;
using Rooms.Domain.Entities;

namespace Rooms.Domain.Mappings;
public static class MapperEntityToValue
{
    public static RoomTypeValue ToRoomTypeValue(this RoomType roomType)
    {
        return new RoomTypeValue(id: roomType.Id, name: roomType.Name);
    }
}