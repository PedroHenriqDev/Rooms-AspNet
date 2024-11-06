using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers.RoomTypes;

public class DeleteRoomTypeHandler : IHandler<DeleteRoomTypeRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoomTypeHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(DeleteRoomTypeRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.RoomTypeRepository.GetByIdAsync(request.Id) is RoomType roomType)
        {
            bool success = await _unitOfWork.RoomTypeRepository.DeleteAsync(roomType);
            return success ? ResponseFactory.Success(value: roomType, message: ResponseResource.DELETED_SUCCESSFULLY_MESSAGE) : ResponseFactory.InternalError(request);
        }

        return ResponseFactory.NotFound(value: request, message: string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));
    }
}
