using Rooms.Domain.Filters;
using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Infra.Utils;

public static class Sanitizer
{
    public static void Sanitize(this RoomFilter filter)
    {
        filter.Name = filter?.Name?.ToLower();
        SanitizeDates(filter);
    }

    public static void SanitizeDates<TFilter>(TFilter? filter) where TFilter : Filter  
    {
        filter!.MinDate = filter?.MinDate == DateTime.MinValue ? new DateTime(1753, 1, 1, 11, 59, 59) : filter!.MinDate;
        filter.MaxDate = filter.MaxDate == DateTime.MinValue ? new DateTime(9999, 12, 31, 11, 59, 59) : filter.MaxDate;
    }
}
