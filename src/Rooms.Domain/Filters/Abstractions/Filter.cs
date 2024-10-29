namespace Rooms.Domain.Filters.Abstractions;

public class Filter
{
    public Filter(DateTime minDate, DateTime maxDate)
    {
        MinDate = minDate;
        MaxDate = maxDate;
    }

    public Filter()
    {
    }

    public DateTime MinDate { get; set; }
    public DateTime MaxDate { get; set; }
}
