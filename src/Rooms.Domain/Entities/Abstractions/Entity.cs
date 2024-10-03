using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Resources;

namespace Rooms.Domain.Entities.Abstractions;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; set; }

    public abstract void Validate();

    public void ValidateId()
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
                string.Format(DomainResource.EMPTY_MESSAGE, nameof(Id))
            )
        );
    }
}