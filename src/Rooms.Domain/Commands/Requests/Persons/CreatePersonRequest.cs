using Rooms.Domain.Commands.Requests.Abstractions;

namespace Rooms.Domain.Commands.Requests.Persons;

public sealed class CreatePersonRequest : CommandRequest
{
    public CreatePersonRequest(string firstName, string lastName, DateTime birthDate, Guid seatId)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        SeatId = seatId;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid SeatId { get; set; } 
}
