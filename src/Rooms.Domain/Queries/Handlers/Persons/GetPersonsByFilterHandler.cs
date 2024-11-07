using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Queries.Requests.Persons;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;

namespace Rooms.Domain.Queries.Handlers.Persons;

public class GetPersonsByFilterHandler : IHandler<GetPersonsByFilterRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPersonsByFilterHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(GetPersonsByFilterRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Person> persons = await _unitOfWork.PersonRepository.GetByFilterAsync(request.Filter);
        return persons != null && persons.Any()
            ? ResponseFactory.Success(persons)
            : ResponseFactory.NotFound(request.Filter, string.Format(ResponseResource.NOT_FOUND_BY_FILTER_MESSAGE, $"{typeof(Person)}s"));
    }
}
