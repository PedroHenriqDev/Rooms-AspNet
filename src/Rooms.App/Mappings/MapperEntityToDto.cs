using Rooms.App.Dto;
using Rooms.Domain.Entities;

namespace Rooms.App.Mappings;

public static class MapperEntityToDto
{
    public static RoomTypeDto ToRoomTypeDto(this RoomType roomType)
    {
        return new RoomTypeDto(id: roomType.Id, name: roomType.Name);
    }

    public static PersonDto ToPersonDto(this Person person) 
    {
        return new PersonDto(firstName: person.Name.FirstName, lastName: person.Name.LastName, birthDate: person.Age.BirthDate, yearsOld: person.Age.YearsOld, person.SeatId);
    }
}