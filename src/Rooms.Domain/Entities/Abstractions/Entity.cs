using Flunt.Notifications;
using Flunt.Validations;

namespace Rooms.Domain.Entities.Abstractions;

public abstract class Entity : Notifiable<Notification>
{
    public Guid Id { get; set; }

    public abstract void Validate();
}