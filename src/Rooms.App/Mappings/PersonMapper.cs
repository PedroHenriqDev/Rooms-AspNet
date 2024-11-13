using Rooms.App.Dto;
using Rooms.Domain.Entities;

namespace Rooms.App.Mappings
{
    public static class PersonMapper
    {
        public static PersonDto ToPersonDto(this Person person)
        {
            return new PersonDto(id: person.Id, firstName: person.Name.FirstName, lastName: person.Name.LastName, birthDate: person.Age.BirthDate, yearsOld: person.Age.YearsOld, person.SeatId);
        }
    }
}
