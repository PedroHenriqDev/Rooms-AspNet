using MediatR;
using Rooms.App.Dto;
using Rooms.App.Mappings;
using Rooms.App.Pagination;
using Rooms.App.QueryParameters;
using Rooms.App.Services.Interfaces;
using Rooms.App.Utils;
using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Entities;
using Rooms.Domain.Filters;
using Rooms.Domain.Queries.Requests.Persons;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses.Interfaces;
using System.Net;

namespace Rooms.App.Services;

public class PersonService : IPersonService
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public PersonService(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> GetAllAsync(PaginationParameters parameters)
    {
        parameters.Deconstruct(out int pageIndex, out int pageSize);

        int offSet = PaginationUtils.CalculateOffSet(pageSize, pageIndex);

        IResponse response = await _mediator.Send(new GetPersonsRequest(pageSize, offSet));

        if(response.StatusCode == HttpStatusCode.OK && response.Success) 
        {
            int totalItems = await _unitOfWork.PersonRepository.CountAsync();

            IEnumerable<Person>? persons = (IEnumerable<Person>?)response.Value;

            response.Value = new PagedList<PersonDto>(pageSize, pageIndex, totalItems, persons?.Select(p => p.ToPersonDto()));
        }

        return response;
    }

    public async Task<IResponse> GetByIdAsync(Guid id)
    {
        IResponse response = await _mediator.Send(new GetPersonByIdRequest(id));

        response.Value = ResponseUtils.ConvertValueToPersonDto(response.Value);

        return response;
    }

    public async Task<IResponse> GetByFilterAsync(PersonFilter filter)
    {
        IResponse response = await _mediator.Send(new GetPersonsByFilterRequest(filter));

        if(response.StatusCode == HttpStatusCode.OK)
        {
            response.Value = ((IEnumerable<Person>)response.Value!).Select(p => p.ToPersonDto());
        }

        return response;
    }

    public async Task<IResponse> CreateAsync(CreatePersonRequest request)
    {
        IResponse response = await _mediator.Send(request);

        response.Value = ResponseUtils.ConvertValueToPersonDto(response.Value);

        return response;
    }

    public async Task<IResponse> UpdateAsync(UpdatePersonRequest request)
    {
        IResponse response = await _mediator.Send(request);

        response.Value = ResponseUtils.ConvertValueToPersonDto(response.Value);

        return response;
    }

    public async Task<IResponse> DeleteAsync(Guid id)
    {
        IResponse response = await _mediator.Send(new DeletePersonRequest(id));

        response.Value = ResponseUtils.ConvertValueToPersonDto(response.Value);

        return response;
    }
}
