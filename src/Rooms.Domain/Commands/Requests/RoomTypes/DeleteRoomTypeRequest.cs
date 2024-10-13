using Flunt.Validations;
using Rooms.Domain.Commands.Requests.Abstractions;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Commands.Requests.RoomTypes;

public class DeleteRoomTypeRequest : CommandRequest
{
    public DeleteRoomTypeRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }

    public override bool Valid()
    {
        AddNotifications
        (
            new Contract<Entity>()
            .Requires()
            .AreNotEquals
            (
                Id,
                Guid.Empty,
                nameof(Id),
                string.Format(ValidationMessagesResource.EMPTY_MESSAGE, nameof(Id)
            )
        ));

        return IsValid;
    }
}
