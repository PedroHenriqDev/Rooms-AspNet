using Rooms.App.QueryParameters;
using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Filters;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IRoomTypeService
{
    Task<IResponse> GetAllAsync(PaginationParameters parameters);

    Task<IResponse> GetByIdAsync(Guid id);

    Task<IResponse> GetByFiltersAsync(RoomTypeFilter filter);

    Task<IResponse> CreateAsync(CreateRoomTypeRequest request);

    Task<IResponse> UpdateAsync(UpdateRoomTypeRequest request);

    Task<IResponse> DeleteAsync(Guid id);
}