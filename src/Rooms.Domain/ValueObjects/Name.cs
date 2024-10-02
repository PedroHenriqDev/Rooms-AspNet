using Flunt.Notifications;
using Flunt.Validations;

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
                "First name cannot be null or empty."
            )
            .IsNotNullOrEmpty
            (
                LastName,
                nameof(LastName),
                "Last name cannot be null or empty."
            )
            .IsGreaterThan
            (
                FirstName.Length,
                MIN_NAME_LENGTH,
                nameof(FirstName),
                $"The {nameof(FirstName)}  length must be greater than {MIN_NAME_LENGTH}"
            )
            .IsLowerThan
            (
                FirstName.Length,
                MIN_NAME_LENGTH,
                nameof(FirstName),
                $"The {nameof(FirstName)} length must be smaller than {MAX_NAME_LENGTH}"
            )
            .IsGreaterThan
            (
                LastName.Length,
                MIN_NAME_LENGTH,
                nameof(LastName),
                $"The {nameof(LastName)}  length must be greater than {MIN_NAME_LENGTH}"
            )
            .IsLowerThan
            (
                LastName.Length,
                MIN_NAME_LENGTH,
                nameof(LastName),
                $"The {nameof(LastName)} length must be smaller than {MAX_NAME_LENGTH}"
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