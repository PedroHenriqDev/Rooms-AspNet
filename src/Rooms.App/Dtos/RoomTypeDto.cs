namespace Rooms.App.Dto;

public class RoomTypeDto
{
    public RoomTypeDto(Guid id, string name, DateTime createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public RoomTypeDto()
    {
        Name = string.Empty;
    }

    public Guid Id {get; set;}
    public string Name {get; set;}
    public DateTime CreatedAt { get; set; }
}