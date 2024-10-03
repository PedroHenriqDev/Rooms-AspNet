using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Resources;

namespace Rooms.Domain.ValueObjects;
public class Name : Notifiable<Notification>
{
    public const long MAX_NAME_LENGTH = 50;
    public const long MIN_NAME_LENGTH = 2;

    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications
        (
            new Contract<Name>()
            .Requires()
            .IsNotNullOrEmpty
            (
                FirstName,
                nameof(FirstName),
                string.Format(DomainResource.NULL_OR_EMPTY_MESSAGE, nameof(FirstName))
            )
            .IsNotNullOrEmpty
            (
                LastName,
                nameof(LastName),
                string.Format(DomainResource.NULL_OR_EMPTY_MESSAGE, nameof(LastName))
            )
            .IsGreaterThan
            (
                FirstName.Length,
                MIN_NAME_LENGTH,
                nameof(FirstName),
                string.Format(DomainResource.GREATER_MESSAGE, nameof(FirstName), MIN_NAME_LENGTH)
            )
            .IsLowerThan
            (
                FirstName.Length,
                MAX_NAME_LENGTH,
                nameof(FirstName),
                string.Format(DomainResource.SMALLER_MESSAGE, nameof(FirstName), MAX_NAME_LENGTH)
            )
            .IsGreaterThan
            (
                LastName.Length,
                MIN_NAME_LENGTH,
                nameof(LastName),
                string.Format(DomainResource.GREATER_MESSAGE, nameof(LastName), MIN_NAME_LENGTH)
            )
            .IsLowerThan
            (
                LastName.Length,
                MAX_NAME_LENGTH,
                nameof(LastName),
                string.Format(DomainResource.SMALLER_MESSAGE, nameof(LastName), MAX_NAME_LENGTH)
            )
        );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}