using System.Net;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers;
public class CreateRoomTypeHandler : IHandler<CreateRoomTypeRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(CreateRoomTypeRequest request, CancellationToken cancellationToken)
    {
        var invalidResponse = new Response
        (
            message: CommandResource.COMMAND_INVALID_MESSAGE,
            statusCode: HttpStatusCode.BadRequest, 
            value: request.Notifications,
            success: false
        );

        if(!request.Valid())
        {
            return invalidResponse;
        }
        
        var roomType = new RoomType(request.Name);

        if(!roomType.IsValid)
        {
            return invalidResponse;
        }

        if(await _unitOfWork.RoomTypeRepository.ExistsNameAsync(request.Name))
        {
            return new Response
            (
                message: string.Format(CommandResource.NAME_EXISTS_MESSAGE, request.Name),
                statusCode: HttpStatusCode.BadRequest, 
                value: request.Name,
                success: false
            );
        }

        await _unitOfWork.RoomTypeRepository.CreateAsync(roomType);

        return new Response
        (
            message: CommandResource.ROOM_TYPE_CREATED_MESSSAGE,
            statusCode: HttpStatusCode.Created, 
            value:  roomType
        );
    }
}