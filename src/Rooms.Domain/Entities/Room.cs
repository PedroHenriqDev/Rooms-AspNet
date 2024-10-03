using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Resources;

namespace Rooms.Domain.Entities;

public class Room : Entity
{
    private DateTime MIN_START_DATE = DateTime.Now;
    private const short MIN_CAPACITY = 0;
    private const int MAX_CAPACITY = int.MaxValue;

    private readonly IList<Seat> _seats;

    public Room
    (
        string name,
        int capacity,
        Guid typeId,
        DateTime startDate,
        DateTime endDate,
        IList<Seat> seats
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        TypeId = typeId;
        StartDate = startDate;
        EndDate = endDate;
        _seats = seats;

        Validate();
    }

    public Room(string name, int capacity, Guid typeId, DateTime startDate, DateTime endDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        TypeId = typeId;
        StartDate = startDate;
        EndDate = endDate;
        _seats = new List<Seat>();

        Validate();
    }

    public Room
    (
        string name,
        int capacity,
        RoomType type,
        DateTime startDate,
        DateTime endDate,
        IList<Seat> seats
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        TypeId = type.Id;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        _seats = seats;

        Validate();
    }

    public Room(string name, int capacity, RoomType type, DateTime startDate, DateTime endDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Capacity = capacity;
        TypeId = type.Id;
        Type = type;
        StartDate = startDate;
        EndDate = endDate;
        _seats = new List<Seat>();

        Validate();
    }

    public string Name {get; private set;}
    public int Capacity {get; private set;}
    public Guid TypeId {get; private set;}
    public RoomType? Type {get; private set;}
    public DateTime StartDate {get; private set;}
    public DateTime EndDate {get; private set;}
    public bool SoldOut => _seats.Count() >= Capacity;
    public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();

    public bool AddSeat(Seat seat)
    {
        if(seat.IsValid && !SoldOut)
        {
            _seats.Add(seat);
            return true;
        }

        return false;
    }

    public bool AddSeats(IList<Seat> seats)
    {
        var seatsOriginal = seats;
        
        foreach(Seat seat in seats)
        {
           var success = AddSeat(seat);
           
           if(!success)
           {
              seatsOriginal = seats;
              return false;
           }
        }

        return true;
    }

    public void ChangeType(RoomType type)
    {
        TypeId = type.Id;
        Type = type;
    }

    public override void Validate()
    {
        ValidateId();

        foreach(Seat seat in Seats)
        {
            AddNotifications(seat.Notifications);
        }

        if(Type != null)
            AddNotifications(Type.Notifications);

        AddNotifications
        (
            new Contract<Room>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Name,
                $"{Id}.{nameof(Name)}",
                string.Format(ValidationResource.NULL_OR_EMPTY_MESSAGE, nameof(Name))
            )
            .AreNotEquals
            (
                TypeId,
                Guid.Empty,
                $"{Id}.{TypeId}",
                string.Format(ValidationResource.EMPTY_MESSAGE, nameof(TypeId))
            )
            .IsGreaterThan
            (
                Capacity,
                MIN_CAPACITY,
                $"{Id}.{nameof(Capacity)}",
                string.Format(ValidationResource.GREATER_MESSAGE, nameof(Capacity), MIN_CAPACITY)
            )
            .IsLowerThan
            (
                Capacity,
                MAX_CAPACITY,
                $"{Id}.{nameof(Capacity)}",
                string.Format(ValidationResource.SMALLER_MESSAGE, nameof(Capacity), MAX_CAPACITY)
            )
            .IsLowerOrEqualsThan
            (
                _seats.Count,
                Capacity,
                $"{Id}.{nameof(Capacity)}",
                string.Format(ValidationResource.SEAT_CAPACITY_EXCEED_MESSAGE, _seats.Count, Capacity)
            )
            .IsLowerOrEqualsThan
            (
                StartDate, 
                EndDate,
                 $"{Id}.{StartDate}&{EndDate}",
                  ValidationResource.START_DATE_EARLIER_MESSAGE
            )
            .IsGreaterOrEqualsThan
            (
                StartDate,
                MIN_START_DATE,
                $"{Id}.{nameof(StartDate)}",
                string.Format(ValidationResource.GREATER_MESSAGE, nameof(StartDate), MIN_START_DATE)
            )
        );
    }
}