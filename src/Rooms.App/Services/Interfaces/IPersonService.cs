using Rooms.App.QueryParameters;
using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Filters;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IPersonService
{

    Task<IResponse> GetAllAsync(PaginationParameters parameters);

    Task<IResponse> GetByIdAsync(Guid id);

    Task<IResponse> GetByFilterAsync(PersonFilter filter);

    Task<IResponse> CreateAsync(CreatePersonRequest request);

    Task<IResponse> UpdateAsync(UpdatePersonRequest request);

    Task<IResponse> DeleteAsync(Guid id);
}
