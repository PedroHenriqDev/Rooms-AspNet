using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Filters;

public class RoomTypeFilter : Filter
{
    public RoomTypeFilter(string? name, DateTime minDate, DateTime maxDate) : base(minDate, maxDate)
    {
        Name = name ?? string.Empty;
    }

    public RoomTypeFilter()
    {
    }

    public string Name { get; set; } = string.Empty;
}
