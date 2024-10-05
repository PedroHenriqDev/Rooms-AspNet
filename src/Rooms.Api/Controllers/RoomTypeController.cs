using Microsoft.AspNetCore.Mvc;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class RoomTypeController : ControllerBase
{
    private readonly IRoomTypeService _service;

    public RoomTypeController(IRoomTypeService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IResponse>> CreateAsync([FromBody] CreateRoomTypeRequest request)
    {
        IResponse response = await _service.CreateAsync(request);
        return StatusCode((int)response.StatusCode, response);
    }
}