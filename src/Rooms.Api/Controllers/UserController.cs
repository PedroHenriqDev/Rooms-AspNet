using Microsoft.AspNetCore.Mvc;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Responses.Interfaces;
using System.Net;

namespace Rooms.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status409Conflict)]
    public async Task<ActionResult<IResponse>> CreateUserAsync([FromBody] CreateUserRequest request)
    {
        IResponse response = await _service.RegisterAsync(request);
        return StatusCode(statusCode: (int)response.StatusCode, value: response);
    }
}
