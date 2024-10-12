using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers;

public class GetRoomTypesHandler : IHandler<GetRoomTypesRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRoomTypesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetRoomTypesRequest request, CancellationToken cancellationToken)
    {
        var rooms = await _unitOfWork.RoomTypeRepository.GetAllAsync(request.OffSet, request.Size);

        if(rooms == null)
        {
            return ResponseFactory.NotFound(request, string.Format(ResponseResource.INVALID_INDEX_MESSAGE, "Rooms"));
        }

        return ResponseFactory.Success(ResponseResource.SUCCESSFUL_REQUEST_MESSAGE, value: rooms);
    }
}