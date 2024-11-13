using Rooms.App.Dto;
using Rooms.Domain.Entities;

namespace Rooms.App.Mappings;

public static class UserMapper
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto(user.Name, user.Email, user.Age.BirthDate, user.Role);
    }
}
