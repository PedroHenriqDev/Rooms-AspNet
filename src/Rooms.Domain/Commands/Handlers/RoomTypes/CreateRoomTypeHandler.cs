using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers.RoomTypes;
public class CreateRoomTypeHandler : IHandler<CreateRoomTypeRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(CreateRoomTypeRequest request, CancellationToken cancellationToken)
    {
        var roomType = new RoomType(request.Name);

        if (!roomType.IsValid)
            return ResponseFactory.BadRequest(roomType.Notifications);

        if (await _unitOfWork.RoomTypeRepository.ExistsNameAsync(request.Name))
            return ResponseFactory.Conflict(request, string.Format(ResponseResource.CONFLICT_NAME_MESSAGE, request.Name));

        bool success = await _unitOfWork.RoomTypeRepository.CreateAsync(roomType);

        return success ? ResponseFactory.Created(value: roomType, message: ResponseResource.CREATED_SUCCESSFULLY_MESSAGE) : ResponseFactory.InternalError(request);
    }
}