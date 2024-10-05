using MediatR;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Interfaces;
public interface IHandler<TRequest> : IRequestHandler<TRequest, IResponse> 
    where TRequest : IRequest<IResponse>
{
}