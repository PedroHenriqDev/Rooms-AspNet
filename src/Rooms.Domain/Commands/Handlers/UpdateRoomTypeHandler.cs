using System.Net;
using Rooms.Domain.Commands.Requests;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers;

public class UpdateRoomTypeHandler : IHandler<UpdateRoomTypeRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(UpdateRoomTypeRequest request, CancellationToken cancellationToken)
    {
        if(!request.Valid())
        {
            return ResponseFactory.BadRequest(request.Notifications);
        }

        if(await _unitOfWork.RoomTypeRepository.GetByIdAsync(request.Id) is RoomType roomType)
        {
            roomType.ChangeName(request.Name);
            await _unitOfWork.RoomTypeRepository.UpdateAsync(roomType);

            return ResponseFactory.Success(ResponseResource.SUCCESSFUL_REQUEST_MESSAGE, value: roomType);
        }

        return ResponseFactory.NotFound(request, string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));
    }
}