using Flunt.Validations;
using Rooms.Domain.Entities.Abstractions;
using Rooms.Domain.Enums;
using Rooms.Domain.Validations;
using Rooms.Domain.ValueObjects;

namespace Rooms.Domain.Entities;

public class User : Entity
{
    public User(string name, string email, string password, Age age, ICollection<Person> persons) : base(Guid.NewGuid(), DateTime.Now)
    {
        Name = name;
        Email = email;
        Password = password;
        Age = age;
        Persons = persons;
        Salt = Guid.NewGuid().ToString().Replace("-", "");
    }

    public User(Guid id, DateTime createdAt, string name, Age age, string email, string password, string salt, EUserRole role)
        : base(id, createdAt)
    {
        Name = name;
        Age = age;
        Email = email;
        Password = password;
        Salt = salt;
        Role = role;
    }

    protected User()
    {
        Name = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        Age = new Age(DateTime.Now);
        Salt = string.Empty;
    }

    public string Name { get; private set; }
    public Age Age { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string Salt { get; private set; }
    public EUserRole Role { get; private set; }
    public ICollection<Person> Persons { get; private set; } = new List<Person>();

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
            .IsEmail
            (
                Email,
                $"{nameof(Email)}"
            )
            .IsNotNullOrEmpty
            (
                Email, 
                $"{Email}.{nameof(Email)}",
                string.Format(ValidationMessagesResource.NULL_OR_EMPTY_MESSAGE, nameof(Email)))
            );
    }
}
