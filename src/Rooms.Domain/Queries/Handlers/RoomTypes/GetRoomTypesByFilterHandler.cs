using MediatR;
using Rooms.Domain.Entities;
using Rooms.Domain.Queries.Requests.RoomTypes;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.RoomTypes;

public sealed class GetRoomTypesByFilterHandler : IRequestHandler<GetRoomTypesByFilterRequest, IResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    
    public GetRoomTypesByFilterHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetRoomTypesByFilterRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<RoomType> roomTypes = await _unitOfWork.RoomTypeRepository.GetByFilterAsync(request.Filter);

        if(roomTypes == null || !roomTypes.Any())
        {
            return ResponseFactory.NotFound(request.Filter, string.Format(ResponseResource.NOT_FOUND_BY_FILTER_MESSAGE, nameof(RoomType)));
        }

        return ResponseFactory.Success(roomTypes);
    }
}
