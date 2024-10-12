using Rooms.App.QueryParameters;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IRoomTypeService
{
    Task<IResponse> GetAllAsync(PaginationParameters parameters);

    Task<IResponse> GetByIdAsync(Guid id);

    Task<IResponse> CreateAsync(CreateRoomTypeRequest request);

    Task<IResponse> UpdateAsync(UpdateRoomTypeRequest request);
}