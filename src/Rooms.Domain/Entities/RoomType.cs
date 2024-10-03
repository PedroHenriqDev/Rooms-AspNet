using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Resources;

namespace Rooms.Domain.Entities;

public class RoomType : Entity
{
    private const short MAX_NAME_LENGTH = 50;

    public RoomType(string name) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;

        Validate();
    }

    public string Name {get; private set;}

    public override void Validate()
    {
        ValidateBase();
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
            .IsLowerOrEqualsThan
            (
                Name.Length,
                MAX_NAME_LENGTH,
                $"{Id}.{nameof(Name)}",
                string.Format(ValidationResource.SMALLER_MESSAGE,
                nameof(Name), MAX_NAME_LENGTH
                )
            )
        );
    }
}