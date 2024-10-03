using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Resources;

namespace Rooms.Domain.Entities.Abstractions;

public abstract class Entity : Notifiable<Notification>
{
    public Entity(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt {get; private set;}

    public abstract void Validate();

    public virtual void ValidateBase()
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
                string.Format(ValidationResource.EMPTY_MESSAGE, nameof(Id))
            )
            .IsLowerOrEqualsThan
            (
                CreatedAt,
                DateTime.Now, 
                $"{Id}.{nameof(CreatedAt)}",
                string.Format(ValidationResource.CANNOT_BE_FUTURE_MESSAGE, nameof(CreatedAt))
            )
        );
    }
}