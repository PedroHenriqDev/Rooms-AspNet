using Rooms.App.Pagination.Interfaces;

namespace Rooms.App.Pagination;

public class PagedList<T> : List<T>, IPagedList<T>
{
    public int PageSize { get; private set;}
    public int PageIndex {get; private set;}
    public int PageCount { get; private set;}
    public int TotalItems {get; private set;}
    public bool HasPrevious => PageCount > 1;
    public bool HasNext => PageCount > PageIndex;

    public PagedList(int pageSize, int pageIndex, int totalItems, IEnumerable<T>? items)
    {
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalItems = totalItems;
        PageCount = (int)Math.Ceiling((decimal)TotalItems / pageSize);
        
        AddRange(items!);
    }
}