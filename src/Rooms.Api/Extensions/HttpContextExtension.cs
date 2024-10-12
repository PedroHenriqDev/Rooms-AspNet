using Rooms.App.Pagination.Interfaces;
using System.Text.Json;

namespace Rooms.Api.Extensions;

public static class HttpContextExtension
{
    public static void AddPaginationHeader<T>(this HttpContext httpContext, IPagedList<T>? items)
    {
        if (items != null)
        {

            object headerValue = new
            {
                PageSize = items.PageSize,
                PageIndex = items.PageIndex,
                PageCount = items.PageCount,
                TotalItems = items.TotalItems,
                HasPrevious = items.HasPrevious,
                HasNext = items.HasNext,
            };

            httpContext.Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(headerValue));
        }
    }
}
