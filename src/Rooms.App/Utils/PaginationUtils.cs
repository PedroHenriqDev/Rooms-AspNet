using Rooms.App.QueryParameters;

namespace Rooms.App.Utils;

public static class PaginationUtils
{
    public static int CalculateOffSet(int pageIndex, int pageSize)
    {
        return (pageIndex - 1) * pageSize; 
    }

    public static (int pageSize, int pageNumber) SanitizePaginationParameter(PaginationParameters parameters)
    {
        int pageSize = parameters.PageSize >= 1 ? parameters.PageSize : int.MaxValue;
        int pageIndex = parameters.PageIndex >= 1 ? parameters.PageIndex : 1;

        return (pageSize, pageIndex);
    }
}