using Flunt.Validations;
using Rooms.Domain.Commands.Requests.Abstractions;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Commands.Requests;

public sealed class CreateRoomTypeRequest : RoomTypeCommandRequest
{
    public string Name { get; set;} = string.Empty;

    public override bool Valid()
    {
        AddNotifications
        (
            new Contract<CreateRoomTypeRequest>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Name,
                nameof(Name),
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(Name))
            )
            .IsLowerOrEqualsThan
            (
                Name.Length,
                ValidationsRules.MAX_ROOM_NAME_LENGTH,
                nameof(Name),
                string.Format(ValidationMessagesResource.SMALLER_MESSAGE, nameof(Name), ValidationsRules.MAX_ROOM_NAME_LENGTH)
            )
        );

        return IsValid; 
    }
}