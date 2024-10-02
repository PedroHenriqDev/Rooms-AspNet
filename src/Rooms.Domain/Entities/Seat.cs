using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;

namespace Rooms.Domain.Entities;

public class Seat : Entity
{
    public Seat(string name, Guid personId)
    {
        Name = name;
        PersonId = personId;

        Validate();
    }

    public Seat(string name, Person person)
    {
        Name = name;
        PersonId = person.Id;
        Person = person;

        Validate();
    }

    public string Name { get; private set; }
    public Guid PersonId {get; private set;}
    public Person? Person {get; private set;}

    public override void Validate()
    {
        AddNotifications(Person?.Notifications);
        AddNotifications
        (
            new Contract<Seat>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Name,
                $"{Id}.{nameof(Name)}",
                $"{nameof(Name)} cannot be null or empty"
            )
            .AreNotEquals
            (
                PersonId,
                 Guid.Empty,
                $"{Id}.{nameof(PersonId)}",
                $"The {nameof(PersonId)} cannot be empty"
            )
        );
    }
}