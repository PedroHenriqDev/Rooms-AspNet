namespace Rooms.App.Pagination.Interfaces;

public interface IPagedList<T>
{
    int PageSize { get; }
    int PageIndex { get; }
    int PageCount { get; }
    int TotalItems { get; }
    bool HasPrevious { get; }
    bool HasNext {get;}
}