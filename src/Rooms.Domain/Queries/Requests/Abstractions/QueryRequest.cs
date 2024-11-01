using MediatR;
using Rooms.Domain.Responses.Interfaces;
using System.Xml.Schema;

namespace Rooms.Domain.Queries.Requests.Abstractions;

public class QueryRequest : IRequest<IResponse>
{
}