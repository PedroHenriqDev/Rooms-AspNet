using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services.Interfaces;

public interface IPersonService
{
    Task<IResponse> CreateAsync(CreatePersonRequest request);
}
