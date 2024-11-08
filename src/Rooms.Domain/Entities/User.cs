using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Enums;
using Rooms.Domain.Validations;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Entities;

public class User : Entity
{
    public User(Name name, string email, string password, Age age, ICollection<Person> persons) : base(Guid.NewGuid(), DateTime.Now)
    {
        Name = name;
        Email = email;
        Password = password;
        Age = age;
        Persons = persons;
    }

    protected User()
    {
        Name = new Name(string.Empty, string.Empty);
        Email = string.Empty;
        Password = string.Empty;
        Age = new Age(DateTime.Now);
        Persons = new List<Person>();
    }

    public Name Name { get; private set; }
    public Age Age { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public EUserRole Role { get; private set; }
    public ICollection<Person> Persons { get; private set; }

    public override void Validate()
    {
        AddNotifications(new Contract<User>()
            .Requires()
            .IsNotNullOrEmpty
            (
                Password,
                $"{Id}.{nameof(Password)}",
                string.Format(ValidationMessagesResource.EMPTY_MESSAGE, nameof(Password))
            )
            .IsNotNullOrEmpty
            (
                Email, 
                $"{Email}.{nameof(Email)}",
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(Email)))
            );
    }
}
