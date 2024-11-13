using MediatR;
using Rooms.App.Dto;
using Rooms.App.Mappings;
using Rooms.App.Pagination;
using Rooms.App.QueryParameters;
using Rooms.App.Services.Interfaces;
using Rooms.App.Utils;
using Rooms.Domain.Commands.Requests.RoomTypes;
using Rooms.Domain.Entities;
using Rooms.Domain.Filters;
using Rooms.Domain.Queries.Requests.RoomTypes;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses.Interfaces;
using System.Net;

namespace Rooms.App.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public RoomTypeService(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> GetAllAsync(PaginationParameters parameters)
    {
        parameters.Deconstruct(out int pageIndex, out int pageSize);

        int offSet = PaginationUtils.CalculateOffSet(pageIndex, pageSize);

        IResponse response = await _mediator.Send(new GetRoomTypesRequest(pageSize, offSet));

        if (response.StatusCode == HttpStatusCode.OK && response.Success)
        {
            int totalItems = await _unitOfWork.RoomTypeRepository.CountAsync();

            var roomTypes = (IEnumerable<RoomType>?)response.Value;

            response.Value = new PagedList<RoomTypeDto>(pageSize, pageIndex, totalItems, roomTypes?.Select(rt => rt.ToRoomTypeDto()));
        }

        return response;
    }

    public async Task<IResponse> GetByIdAsync(Guid id)
    {
        IResponse response = await _mediator.Send(new GetRoomTypeByIdRequest(id));

        response.Value = DtoConverter.ValueToRoomTypeDto(response.Value);

        return response;
    }

    public async Task<IResponse> GetByFiltersAsync(RoomFilter filter)
    {
        IResponse response = await _mediator.Send(new GetRoomTypesByFilterRequest(filter));

        response.Value = DtoConverter.ValueToRoomTypeDto(response.Value);

        if(response.StatusCode == HttpStatusCode.OK) 
        {
            response.Value = ((IEnumerable<RoomType>)response.Value!).Select(r => r.ToRoomTypeDto());
        }

        return response;
    }

    public async Task<IResponse> CreateAsync(CreateRoomTypeRequest request)
    {
        IResponse response = await _mediator.Send(request);

        response.Value = DtoConverter.ValueToRoomTypeDto(response.Value);

        return response;
    }

    public async Task<IResponse> UpdateAsync(UpdateRoomTypeRequest request)
    {
        IResponse response = await _mediator.Send(request);

        response.Value = DtoConverter.ValueToRoomTypeDto(response.Value);

        return response;
    }

    public async Task<IResponse> DeleteAsync(Guid id)
    {
        IResponse response = await _mediator.Send(new DeleteRoomTypeRequest(id));

        response.Value = DtoConverter.ValueToRoomTypeDto(response.Value);

        return response;
    }
}