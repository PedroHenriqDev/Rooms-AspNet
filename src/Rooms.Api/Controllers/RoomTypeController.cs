using Microsoft.AspNetCore.Mvc;
using Rooms.Api.Extensions;
using Rooms.App.Pagination.Interfaces;
using Rooms.App.QueryParameters;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Entities;
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
       
    [HttpGet]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IResponse>> GetAllAsync([FromQuery] PaginationParameters parameters)
    {
        IResponse response = await _service.GetAllAsync(parameters);

        HttpContext.AddPaginationHeader((IPagedList<RoomType>?)response.Value);

        return StatusCode(statusCode: (int)response.StatusCode, value: response);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IResponse>> GetByIdAsync([FromRoute] Guid id) 
    {
        IResponse response = await _service.GetByIdAsync(id);
        return StatusCode(statusCode:  (int)response.StatusCode, value:response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IResponse>> CreateAsync([FromBody] CreateRoomTypeRequest request)
    {
        IResponse response = await _service.CreateAsync(request);
        return StatusCode(statusCode: (int)response.StatusCode, value: response);
    }

    [HttpPut]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IResponse>> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRoomTypeRequest request) 
    {
        request.Id = id;
        IResponse response = await _service.UpdateAsync(request);
        return StatusCode(statusCode: (int)response.StatusCode, value: response);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(IResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IResponse>> UpdateAsync([FromRoute] Guid id) 
    {
        IResponse response = await _service.DeleteAsync(id);
        return StatusCode(statusCode: (int)response.StatusCode, value: response);
    }
}