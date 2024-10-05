using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Commands.Responses.Interfaces;

namespace Rooms.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class RoomTypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoomTypeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ICommandResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ICommandResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ICommandResponse>> CreateAsync([FromBody] CreateRoomTypeRequest request)
    {
        ICommandResponse response = await _mediator.Send(request);
        return StatusCode((int)response.StatusCode, response);
    }
}