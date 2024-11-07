using Rooms.Domain.Filters.Abstractions;

namespace Rooms.Domain.Filters;

public class PersonFilter : Filter
{
    public PersonFilter() : base(new DateTime(), DateTime.Now)
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        BirthDateMin = MinDate;
        BirthDateMax = MaxDate;
        SeatName = string.Empty;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDateMin { get; set; }
    public DateTime? BirthDateMax { get; set; }
    public string? SeatName { get; set; } 
}
