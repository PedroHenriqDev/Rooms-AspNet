using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Enums;

namespace Rooms.Domain.Entities;

public class Room : Entity
{
    private const long MIN_CAPACITY = 0;
    private const int MAX_CAPACITY = int.MaxValue;

    private readonly IList<Seat> _seats;

    public Room(string name, int capacity, IList<Seat> seats, ERoomType type = ERoomType.Multipurpose)
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        Type = type;
        _seats = seats;

        Validate();
    }

    public Room(string name, int capacity, ERoomType type = ERoomType.Multipurpose)
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        Type = type;
        _seats = new List<Seat>();

        Validate();
    }

    public string Name {get; private set;}
    public int Capacity {get; private set;}
    public ERoomType Type {get; private set;}
    public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

    public void AddSeat(Seat seat)
    {
        if(seat.IsValid)
            _seats.Add(seat);
    }

    public void AddSeats(IList<Seat> seats)
    {
        foreach(Seat seat in seats)
        {
            AddSeat(seat);
        }
    }

    public void ChangeType(ERoomType type = ERoomType.Multipurpose)
    {
        Type = type;
    }

    public override void Validate()
    {
        foreach(Seat seat in Seats)
        {
            AddNotifications(seat.Notifications);
        }

        AddNotifications
        (
            new Contract<Room>()
            .Requires()
            .IsNullOrEmpty
            (
                Name,
                $"{Id}.{nameof(Name)}",
                $"The {Name} cannot be null or empty."
            )
            .IsGreaterThan
            (
                Capacity,
                MIN_CAPACITY,
                $"{Id}.{nameof(Capacity)}",
                $"The {nameof(Capacity)} must be greater than {MIN_CAPACITY}"
            )
            .IsLowerThan
            (
                Capacity,
                MAX_CAPACITY,
                $"{Id}.{nameof(Capacity)}",
                $"The {nameof(Capacity)} must be smaller than {MIN_CAPACITY}"
            )
            .IsLowerOrEqualsThan
            (
                Seats.Count,
                Capacity,
                $"{Id}.{nameof(Capacity)}",
                $"The number of seats ({Seats.Count}) cannot exceed the room's capacity of {Capacity}."
            )
        );
    }
}