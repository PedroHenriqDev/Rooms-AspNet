using MediatR;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Requests.Abstractions;

public class QueryRequest : IRequest<IResponse>
{
}