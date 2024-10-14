using MediatR;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services;

public class PersonService : IPersonService
{
    private readonly IMediator _mediator;

    public PersonService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResponse> CreateAsync(CreatePersonRequest request)
    {
        IResponse response = await _mediator.Send(request);

        response.Value = ResponseUtils.ConvertValueToPersonDto(response.Value);

        return response;
    }
}
