namespace Rooms.Domain.Commands.Responses;

public class RoomTypeValue
{
    public RoomTypeValue(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public RoomTypeValue()
    {
        Name = string.Empty;
    }

    public Guid Id {get; set;}
    public string Name {get; set;}
}