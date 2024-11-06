using Rooms.Domain.Commands.Requests.Abstractions;
using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Commands.Handlers.Persons;

public class DeletePersonHandler : IHandler<DeletePersonRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeletePersonHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
    {
        if(await _unitOfWork.PersonRepository.GetByIdAsync(request.Id) is Person person)
        {
           bool success = await _unitOfWork.PersonRepository.DeleteAsync(person);
           return success ? ResponseFactory.Success(person) : ResponseFactory.InternalError(request);
        }

        return ResponseFactory.NotFound(request, string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));    
    }
}
