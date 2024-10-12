using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers;

public sealed class GetRoomTypesHandler : IHandler<GetRoomTypesRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetRoomTypesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetRoomTypesRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.RoomTypeRepository.GetAllAsync(request.OffSet, request.Size) is IEnumerable<RoomType> roomTypes)
        {
            return ResponseFactory.Success(value: roomTypes);
        }

        return ResponseFactory.NotFound(request, string.Format(ResponseResource.INVALID_INDEX_MESSAGE, "Rooms"));
    }
}