using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Entities;

public class Person : Entity
{
    public Person(Name name, Age age,  Guid seatId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        SeatId = seatId;

        Validate();
    }

    public Person(Name name, Age age, Seat seat)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
        SeatId = seat.Id;
        Seat = seat;

        Validate();
    }

    public Name Name { get; private set; }
    public Age Age { get; private set; }  
    public Guid SeatId { get; private set; }
    public Seat? Seat {get; private set; }

    public override void Validate()
    {
        if(Seat != null)
            AddNotifications(Seat?.Notifications);

        AddNotifications(Name.Notifications);
        AddNotifications(Age.Notifications);

        AddNotifications
        (
            new Contract<Person>()
            .Requires()
            .IsNotNull
            (
                Name,
                $"{Id}.{nameof(Name)}",
                $"{nameof(Name)} cannot be null."
            )
            .IsNotNull
            (
                Age,
                $"{Id}.{nameof(Age)}",
                $"{nameof(Age)} cannot be null."
            )
            .AreNotEquals
            (
                SeatId,
                Guid.Empty,
                $"{Id}.{nameof(SeatId)}",
                $"{nameof(SeatId)} cannot be empty."
            )
        );
    }
}