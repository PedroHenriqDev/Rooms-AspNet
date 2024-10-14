using Rooms.App.Mappings;
using Rooms.Domain.Entities;

public static class ResponseUtils
{
    public static object? ConvertValueToRoomTypeDto(object? value)
    {
        if (value is RoomType roomType)
        {
            value = roomType.ToRoomTypeDto();
        }

        return value;
    }

    public static object? ConvertValueToPersonDto(object? value)
    {
        if (value is Person person)
        {
            value = person.ToPersonDto();
        }

        return value;
    }
}
