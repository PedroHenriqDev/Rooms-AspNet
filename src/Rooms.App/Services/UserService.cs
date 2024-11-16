using MediatR;
using Rooms.App.Dtos;
using Rooms.App.Mappings;
using Rooms.App.Resources;
using Rooms.App.Services.Interfaces;
using Rooms.App.Utils;
using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Entities;
using Rooms.Domain.Queries.Requests.Users;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Security.Claims;

namespace Rooms.App.Services;

public class UserService : IUserService
{
    private readonly IMediator _mediator;
    private readonly ICryptoService _cryptoService;
    private readonly IAuthService _authService;
    private readonly IClaimService _claimService;

    public UserService(IMediator mediator, ICryptoService cryptoService, IAuthService authService, IClaimService claimService)
    {
        _mediator = mediator;
        _cryptoService = cryptoService;
        _authService = authService;
        _claimService = claimService;
    }

    public async Task<IResponse> GetByEmailAsync(string email)
    {
        IResponse response = await _mediator.Send(new GetUserByEmailRequest(email));

        response.Value = DtoConverter.ValueToUserDto(response.Value);

        return response;
    }

    public async Task<IResponse> GetByNameAsync(string name)
    {
        IResponse response = await _mediator.Send(new GetUserByEmailRequest(name));

        response.Value = DtoConverter.ValueToUserDto(response.Value);

        return response;
    }

    public async Task<IResponse> LoginAsync(LoginDto login)
    {
        if (string.IsNullOrEmpty(login.Email))
        {
            return ResponseFactory.Unauthorized(login, AppMessagesResource.LOGIN_INVALID_MESSAGE);
        }

        IResponse response = await _mediator.Send(new GetUserByEmailRequest(login.Email));

        if (response.StatusCode != HttpStatusCode.OK) 
        {
            return ResponseFactory.Unauthorized(login, AppMessagesResource.LOGIN_INVALID_MESSAGE);
        }

        var user = (User?)response.Value;

        string loginPassword = login.Password.ConcatSalt(user!.Salt);
        var password = _cryptoService.Decrypt(user.Password).ConcatSalt(user.Salt);

        if (loginPassword != password)
        {
            return ResponseFactory.Unauthorized(login, AppMessagesResource.LOGIN_INVALID_MESSAGE);
        }

        IList<Claim> authClaims = _claimService.GenerateAuthClaims(user.ToUserDto());
        AuthenticationDto authentication = _authService.Authenticate(authClaims);

        return ResponseFactory.Success(authentication, AppMessagesResource.LOGIN_SUCCESSFULLY_MESSAGE);
    }

    public async Task<IResponse> RegisterAsync(CreateUserRequest request)
    {
        request.Password = _cryptoService.Encrypt(request.Password);

        IResponse response = await _mediator.Send(request);

        response.Value = DtoConverter.ValueToUserDto(response.Value);

        return response;
    }
}
