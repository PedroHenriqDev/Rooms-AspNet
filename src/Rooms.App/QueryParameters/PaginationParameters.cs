namespace Rooms.App.QueryParameters;

public class PaginationParameters
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }

    public void Deconstruct(out int pageIndex, out int pageSize) 
    {
        pageSize = PageSize >= 1 ? PageSize : int.MaxValue;
        pageIndex = PageIndex >= 1 ? PageIndex : 1;
    }
}