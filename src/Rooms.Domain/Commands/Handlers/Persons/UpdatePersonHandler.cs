using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Commands.Handlers.Persons;

public class UpdatePersonHandler : IHandler<UpdatePersonRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePersonHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var personToUpdate = new Person(request.Id, DateTime.Now, new Name(request.FirstName, request.LastName), new Age(request.BirthDate), request.SeatId);

        if (!personToUpdate.IsValid)
        {
            return ResponseFactory.BadRequest(personToUpdate.Notifications);
        }

        if(await _unitOfWork.SeatRepository.GetByIdAsync(request.SeatId) == null)
        {
            return ResponseFactory.NotFound(request, string.Format(ResponseResource.NOT_FOUND_SEAT, request.SeatId));
        }

        if (await _unitOfWork.PersonRepository.GetByIdAsync(request.Id) is Person person)
        {
            personToUpdate.ChangeCreatedAt(person.CreatedAt);
            bool success = await _unitOfWork.PersonRepository.UpdateAsync(personToUpdate);

            return success ? ResponseFactory.Success(value: personToUpdate) : ResponseFactory.InternalError(request);
        }

        return ResponseFactory.NotFound(request, string.Format(ResponseResource.NOT_FOUND_ID_MESSAGE, request.Id));
    }
}
