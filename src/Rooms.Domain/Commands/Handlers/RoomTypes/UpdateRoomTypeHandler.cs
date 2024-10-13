using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers.RoomTypes;

public class UpdateRoomTypeHandler : IHandler<UpdateRoomTypeRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(UpdateRoomTypeRequest request, CancellationToken cancellationToken)
    {
        if (!request.Valid())
            return ResponseFactory.BadRequest(request.Notifications);

        RoomType? roomType = await _unitOfWork.RoomTypeRepository.GetByIdAsync(request.Id);

        if (roomType == null)
            return ResponseFactory.NotFound(request, string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));

        roomType.ChangeName(request.Name);
        roomType.Validate();

        if(!roomType.IsValid)
            return ResponseFactory.BadRequest(request.Notifications);

        await _unitOfWork.RoomTypeRepository.UpdateAsync(roomType);

        return ResponseFactory.Success(value: roomType, message: ResponseResource.UPDATED_SUCCESSFULLY_MESSAGE);
    }
}