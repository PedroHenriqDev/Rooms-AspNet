using MediatR;
using Rooms.App.Mappings;
using Rooms.App.Services.Interfaces;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Entities;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.App.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IMediator _mediator;

    public RoomTypeService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResponse> CreateAsync(CreateRoomTypeRequest request)
    {
        IResponse response = await _mediator.Send(request);
        
        if(response.Value is RoomType roomType)
        {
        response.Value = roomType?.ToRoomTypeValue();
        }
      
        return response;
    }
}