using MediatR;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;
    private readonly ICryptoService _cryptoService;

    public UserService(IMediator mediator, ICryptoService cryptoService)
    {
        _mediator = mediator;
        _cryptoService = cryptoService;
    }

    public async Task<IResponse> RegisterAsync(CreateUserRequest request)
    {
        request.Password = _cryptoService.Encrypt(request.Password);

        IResponse response = await _mediator.Send(request);

        response.Value = DtoConverter.ValueToUserDto(response.Value);

        return response;
    }
}
