using System.Net;
using MediatR;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Commands.Responses;
using Rooms.Domain.Commands.Responses.Interfaces;
using Rooms.Domain.Entities;
using Rooms.Domain.Mappings;
using Rooms.Domain.Repositories;

namespace Rooms.Domain.Commands.Handlers;
public class CreateRoomTypeHandler : IRequestHandler<CreateRoomTypeRequest, ICommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ICommandResponse> Handle(CreateRoomTypeRequest request, CancellationToken cancellationToken)
    {
        var invalidResponse = new CommandResponse
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
            return new CommandResponse
            (
                message: string.Format(CommandResource.NAME_EXISTS_MESSAGE, request.Name),
                statusCode: HttpStatusCode.BadRequest, 
                value: request.Name,
                success: false
            );
        }

        await _unitOfWork.RoomTypeRepository.CreateAsync(roomType);

        return new CommandResponse
        (
            message: CommandResource.ROOM_TYPE_CREATED_MESSSAGE,
            statusCode: HttpStatusCode.Created, 
            value:  roomType.ToRoomTypeValue()
        );
    }
}