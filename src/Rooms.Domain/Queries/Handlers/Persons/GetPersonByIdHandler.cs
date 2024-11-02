using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.Persons;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.Persons;

public sealed class GetPersonByIdHandler : IHandler<GetPersonByIdRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPersonByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.PersonRepository.GetByIdAsync(request.Id) is Person person) 
        {
            return ResponseFactory.Success(person);
        }

        return ResponseFactory.NotFound(value: request.Id, message: string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));
    }
}
