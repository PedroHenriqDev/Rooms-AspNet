using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Validations;
using Rooms.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace Rooms.Domain.Entities;

public class Person : Entity
{
    public Person(Guid id, DateTime createdAt, Name name, Age age, Guid seatId)
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        Age = age;
        SeatId = seatId;

        Validate();
    }

    public Person(Name name, Age age,  Guid seatId) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;
        Age = age;
        SeatId = seatId;

        Validate();
    }

    public Person(Name name, Age age, Seat seat) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;
        Age = age;
        SeatId = seat.Id;
        Seat = seat;

        Validate();
    }

    protected Person()
    {
    }

    public Name Name { get; private set; } = new Name(string.Empty, string.Empty);
    public Age Age { get; private set; } = new Age(DateTime.MinValue);
    public Guid SeatId { get; private set; }
    public Seat? Seat {get; private set; }
    public Guid UserId { get; private set; }
    public User? User { get; private set; }

    internal void ChangeCreatedAt(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public override void Validate()
    {
        ValidateBase();
        
        if(Seat != null)
            AddNotifications(Seat?.Notifications);

        AddNotifications(Name.Notifications);
        AddNotifications(Age.Notifications);

        AddNotifications
        (
            new Contract<Room>()
            .Requires()
            .AreNotEquals
            (
                SeatId,
                Guid.Empty,
                nameof(SeatId),
                string.Format(ValidationMessagesResource.EMPTY_MESSAGE, nameof(SeatId))
            )
        );
    }
}