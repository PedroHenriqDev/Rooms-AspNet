namespace Rooms.Domain.Validations;

public struct ValidationsRules
{
    public const short MAX_NAME_LENGTH = 50;
    public const short MIN_NAME_LENGTH = 2;
    public const short MIN_YEARS_OLD = 0;
    public const short MAX_YEARS_OLD = 120;
    public static DateTime MIN_START_DATE = DateTime.Now;
    public const short MIN_CAPACITY = 0;
    public const int MAX_CAPACITY = int.MaxValue;
    public const int MAX_ROOM_NAME_LENGTH = 100;
}