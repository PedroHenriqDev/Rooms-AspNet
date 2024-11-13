using Rooms.Domain.Commands.Requests.Users;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Commands.Handlers.Users;

public sealed class CreateUserHandler : IHandler<CreateUserRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.Password, new Age(request.BirthDate), new List<Person>());
        user.Validate();

        if (!user.IsValid)
            return ResponseFactory.BadRequest(user.Notifications);

        if(await _unitOfWork.UserRepository.ExistsNameAsync(request.Name)) 
            return ResponseFactory.Conflict(string.Format(ResponseResource.CONFLICT_NAME_MESSAGE, request.Name));

        bool success = await _unitOfWork.UserRepository.CreateAsync(user);

        return success ? ResponseFactory.Success(user) : ResponseFactory.InternalError(request);
    }
}
