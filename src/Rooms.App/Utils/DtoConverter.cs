using Rooms.App.Mappings;
using Rooms.Domain.Entities;

public static class DtoConverter
{
    public static object? ValueToRoomTypeDto(object? value)
    {
        if (value is RoomType roomType)
        {
            value = roomType.ToRoomTypeDto();
        }

        return value;
    }

    public static object? ValueToPersonDto(object? value)
    {
        if (value is Person person)
        {
            value = person.ToPersonDto();
        }

        return value;
    }

    public static object? ValueToUserDto(object? value)
    {
        if(value is User user)
        {
            value = user.ToUserDto();
        }

        return value;
    }
}
