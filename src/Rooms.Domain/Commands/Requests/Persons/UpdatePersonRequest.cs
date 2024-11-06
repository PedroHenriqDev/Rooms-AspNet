using Rooms.Domain.Commands.Requests.Abstractions;
using System.Text.Json.Serialization;

namespace Rooms.Domain.Commands.Requests.Persons;

public sealed class UpdatePersonRequest : CommandRequest
{
    public UpdatePersonRequest(string firstName, string lastName, DateTime birthDate, Guid seatId)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
        SeatId = seatId;
    }

    [JsonIgnore]
    public Guid Id {  get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Guid SeatId { get; set; }
}
