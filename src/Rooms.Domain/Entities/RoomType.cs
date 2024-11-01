using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Entities;

public class RoomType : Entity
{
    protected RoomType()
    {
        Name = string.Empty;
    }

    public RoomType(string name) : base(id: Guid.NewGuid(), createdAt: DateTime.Now)
    {
        Name = name;

        Validate();
    }

    public string Name {get; private set;}

    public void ChangeName(string name)
    {
        Name = name;
    }

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
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(Name))
            )
            .IsLowerOrEqualsThan
            (
                Name.Length,
                ValidationsRules.MAX_NAME_LENGTH,
                $"{Id}.{nameof(Name)}",
                string.Format(ValidationMessagesResource.SMALLER_MESSAGE,
                nameof(Name), ValidationsRules.MAX_NAME_LENGTH
                )
            )
        );
    }
}