﻿using Rooms.Domain.Commands.Requests.Persons;
using Rooms.Domain.Entities;
using Rooms.Domain.Interfaces;
using Rooms.Domain.Repositories;
using Rooms.Domain.Responses;
using Rooms.Domain.Responses.Factories;
using Rooms.Domain.Responses.Interfaces;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Commands.Handlers.Persons;

public sealed class CreatePersonHandler : IHandler<CreatePersonRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResponse> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = new Person(new Name(request.FirstName, request.LastName), new Age(request.BirthDate), request.SeatId);

        if (!person.IsValid) 
            return ResponseFactory.BadRequest(person.Notifications);

        await _unitOfWork.PersonRepository.CreateAsync(person);
        return ResponseFactory.Created(person, ResponseResource.CREATED_SUCCESSFULLY_MESSAGE);
    }
}
