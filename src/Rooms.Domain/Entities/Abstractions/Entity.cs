using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Validations;

namespace Rooms.Domain.Entities.Abstractions;

public abstract class Entity : Notifiable<Notification>
{
    public Entity(Guid id, DateTime createdAt)
    {
        Id = id;
        CreatedAt = createdAt;
    }

    public Entity()
    {
    }

    public Guid Id { get; protected set; }
    public DateTime CreatedAt {get; protected set;}

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
                string.Format(ValidationMessagesResource.EMPTY_MESSAGE, nameof(Id))
            )
            .IsLowerOrEqualsThan
            (
                CreatedAt,
                DateTime.Now, 
                $"{Id}.{nameof(CreatedAt)}",
                string.Format(ValidationMessagesResource.CANNOT_BE_FUTURE_MESSAGE, nameof(CreatedAt))
            )
        );
    }
}