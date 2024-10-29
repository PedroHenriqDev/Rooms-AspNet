using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Validations;

namespace Rooms.Domain.ValueObjects;

public class Name : Notifiable<Notification>
{
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
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(FirstName))
            )
            .IsNotNullOrEmpty
            (
                LastName,
                nameof(LastName),
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(LastName))
            )
            .IsGreaterThan
            (
                FirstName.Length,
                ValidationsRules.MIN_NAME_LENGTH,
                nameof(FirstName),
                string.Format(ValidationMessagesResource.GREATER_MESSAGE, nameof(FirstName), ValidationsRules.MIN_NAME_LENGTH)
            )
            .IsLowerThan
            (
                FirstName.Length,
                ValidationsRules.MAX_NAME_LENGTH,
                nameof(FirstName),
                string.Format(ValidationMessagesResource.SMALLER_MESSAGE, nameof(FirstName), ValidationsRules.MAX_NAME_LENGTH)
            )
            .IsGreaterThan
            (
                LastName.Length,
                ValidationsRules.MIN_NAME_LENGTH,
                nameof(LastName),
                string.Format(ValidationMessagesResource.GREATER_MESSAGE, nameof(LastName), ValidationsRules.MIN_NAME_LENGTH)
            )
            .IsLowerThan
            (
                LastName.Length,
                ValidationsRules.MAX_NAME_LENGTH,
                nameof(LastName),
                string.Format(ValidationMessagesResource.SMALLER_MESSAGE, nameof(LastName), ValidationsRules.MAX_NAME_LENGTH)
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