using Microsoft.AspNetCore.Mvc;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _service;

    public PersonController(IPersonService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<IResponse>> CreateAsync([FromBody] CreatePersonRequest request) 
    {
        IResponse response = await _service.CreateAsync(request);
        return StatusCode((int)response.StatusCode, response);
    }
}
