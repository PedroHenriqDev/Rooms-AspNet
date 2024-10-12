namespace Rooms.App.Utils;
public static class PaginationUtils
{
    public static int CalculateOffSet(int pageSize, int pageIndex)
    {
        return (pageIndex - 1) * pageSize; 
    }
}