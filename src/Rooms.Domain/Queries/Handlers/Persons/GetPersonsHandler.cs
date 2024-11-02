using MediatR;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.Persons;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.Persons;

public sealed class GetPersonsHandler : IHandler<GetPersonsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPersonsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetPersonsRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Person> persons = await _unitOfWork.PersonRepository.GetAllAsync(request.OffSet, request.Size);
        
        if(persons == null || !persons.Any()) 
        {
            return ResponseFactory.NotFound(request);
        }

        return ResponseFactory.Success(persons);
    }
}
