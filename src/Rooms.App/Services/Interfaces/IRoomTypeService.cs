using Rooms.App.QueryParameters;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IRoomTypeService
{
    Task<IResponse> CreateAsync(CreateRoomTypeRequest request);

    Task<IResponse> GetAllAsync(PaginationParameters parameters);

    Task<IResponse> UpdateAsync(UpdateRoomTypeRequest request);
}