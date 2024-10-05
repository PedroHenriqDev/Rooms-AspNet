namespace Rooms.App.Dto;

public class RoomTypeDto
{
    public RoomTypeDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public RoomTypeDto()
    {
        Name = string.Empty;
    }

    public Guid Id {get; set;}
    public string Name {get; set;}
}