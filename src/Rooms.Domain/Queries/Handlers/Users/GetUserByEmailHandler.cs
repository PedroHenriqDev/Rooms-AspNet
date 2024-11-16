using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.Users;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.Users;

public class GetUserByEmailHandler : IHandler<GetUserByEmailRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetUserByEmailHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetUserByEmailRequest request, CancellationToken cancellationToken)
    {
        if(await _unitOfWork.UserRepository.GetByEmailAsync(request.Email) is User user)
        {
            return ResponseFactory.Success(user);
        }

        return ResponseFactory.NotFound(request, message: string.Format(ResponseResource.NOT_FOUND_EMAIL_MESSAGE, request.Email));
    }
}
