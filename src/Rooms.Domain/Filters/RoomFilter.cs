using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Filters;

public class RoomFilter : Filter
{
    public RoomFilter(string? name, DateTime minDate, DateTime maxDate) : base(minDate, maxDate)
    {
        Name = name ?? string.Empty;
    }

    public RoomFilter()
    {
        Name = string.Empty;
    }

    public string? Name { get; set; } = string.Empty;
}
