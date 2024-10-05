using Flunt.Validations;
using Rooms.Domain.Commands.Requests.Abstractions;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Commands.Requests;

public sealed class CreateRoomTypeRequest : RoomTypeCommandRequest
{
    public CreateRoomTypeRequest(string name)
    {
        Name = name;
    }

    public CreateRoomTypeRequest()
    {
        Name = string.Empty;
    }


    public string Name { get; set;}

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