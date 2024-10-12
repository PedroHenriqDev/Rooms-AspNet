using Rooms.App.Mappings;
using Rooms.Domain.Entities;

public static class ResponseUtils
{
    public static object? ConvertValueToRoomTypeDto(object? value)
    {
        if(value is RoomType roomType) 
        {
            value = roomType.ToRoomTypeValue();
        }

        return value;
    }
}
