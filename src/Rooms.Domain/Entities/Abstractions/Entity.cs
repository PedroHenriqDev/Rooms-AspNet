using Flunt.Notifications;
using Flunt.Validations;

namespace Rooms.Domain.Entities.Abstractions;

public abstract class Entity : Notifiable<Notification>
{
    public Entity(Guid id)
    {
        Id = id;

        Validate();
    }

    public Entity()
    {
        Id = Guid.NewGuid();

        Validate();
    }

    public Guid Id { get; private set; }

    public virtual void Validate()
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
                $"{nameof(Id)} cannot be empty."
            )
        );
    }
}