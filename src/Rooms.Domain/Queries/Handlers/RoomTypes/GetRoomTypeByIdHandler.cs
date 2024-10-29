using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.RoomTypes;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers;

public sealed class GetRoomTypeByIdHandler : IHandler<GetRoomTypeByIdRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRoomTypeByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetRoomTypeByIdRequest request, CancellationToken cancellationToken)
    {
        if(await _unitOfWork.RoomTypeRepository.GetByIdAsync(request.Id) is RoomType roomType) 
        {
            return ResponseFactory.Success(value: roomType);
        }

        return ResponseFactory.NotFound(value: request, message: string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));
    }
}
