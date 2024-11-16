using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.Users;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.Users;

public class GetUserByNameHandler : IHandler<GetUserByNameRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByNameHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetUserByNameRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.UserRepository.GetByNameAsync(request.Name) is User user)
        {
            return ResponseFactory.Success(user);
        }

        return ResponseFactory.NotFound(request, message: string.Format(ResponseResource.NOT_FOUND_NAME_MESSAGE, request.Name));
    }
}
