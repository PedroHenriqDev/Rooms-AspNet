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
            message: "Room type is invalid.",
            statusCode: HttpStatusCode.BadRequest, 
            value: request,
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
                message: $"This {request.Name} exists.",
                statusCode: HttpStatusCode.BadRequest, 
                value: request,
                success: false
            );
        }

        await _unitOfWork.RoomTypeRepository.CreateAsync(roomType);

        return new CommandResponse
        (
            message: "Room type created.",
            statusCode: HttpStatusCode.Created, 
            value:  roomType.ToRoomTypeValue()
        );
    }
}