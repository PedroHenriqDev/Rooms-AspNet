using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Entities;

public class Seat : Entity
{
    private const short EQUAL_NAME_LENGTH = 3;

    protected Seat()
    {
        Name = string.Empty;

        Validate();
    }

    public Seat(string name, Guid roomId) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;
        RoomId = roomId;

        Validate();
    }

    public Seat(string name, Room room) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;
        RoomId = room.Id;
        Room = room;

        Validate();
    }

    public string Name { get; private set; }
    public Guid RoomId {get; private set;}
    public Room? Room {get; private set;}

    public override void Validate()
    {
        ValidateBase();

        if(Room != null)
          AddNotifications(Room?.Notifications);

        AddNotifications    
        (
            new Contract<Seat>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Name,
                $"{Id}.{nameof(Name)}",
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(Name))
            )
            .AreEquals 
            (
                Name.Length,
                EQUAL_NAME_LENGTH,
                $"{Id}.{nameof(Name)}",
                string.Format(ValidationMessagesResource.EQUAL_LENGTH_MESSAGE, nameof(Name), EQUAL_NAME_LENGTH)
            )
            .AreNotEquals
            (
                RoomId,
                Guid.Empty,
                $"{Id}.{nameof(RoomId)}",
                string.Format(ValidationMessagesResource.EMPTY_MESSAGE, nameof(RoomId))
            )
        );
    }
}