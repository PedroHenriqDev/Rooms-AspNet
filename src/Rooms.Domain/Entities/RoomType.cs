using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Resources;

namespace Rooms.Domain.Entities;

public class RoomType : Entity
{
    public RoomType(string name)
    {
        Id = Guid.NewGuid();
        Name = name;

        Validate();
    }

    public string Name {get; private set;}

    public override void Validate()
    {
        ValidateId();
        AddNotifications
        (
            new Contract<RoomType>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Name,
                $"{Id}{nameof(Name)}",
                string.Format(ValidationResource.NULL_OR_EMPTY_MESSAGE, nameof(Name))
            )
        );
    }
}