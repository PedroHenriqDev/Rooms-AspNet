namespace Rooms.Domain.Filters.Abstractions;

public class Filter
{
    protected static DateTime MAX_DATE_SQL = new DateTime(9999, 12, 31);
    protected static DateTime MIN_DATE_SQL = new DateTime(1753, 1, 1);

    public Filter(DateTime minDate, DateTime maxDate)
    {
        MinDate = minDate >= MIN_DATE_SQL ? minDate : MIN_DATE_SQL;
        MaxDate = maxDate <= MAX_DATE_SQL ? maxDate : MAX_DATE_SQL;
    }

    public Filter()
    {
    }

    public DateTime MinDate { get; set; }
    public DateTime MaxDate { get; set; }
}
