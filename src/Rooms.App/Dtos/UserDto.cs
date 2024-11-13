using Rooms.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Rooms.App.Dto;

public sealed class UserDto
{
    public UserDto(string name, string email, DateTime birthDate, EUserRole role)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Role = role.ToString();
    }

    public UserDto(string name, string email, DateTime birthDate, string role)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Role = role;
    }

    public UserDto()
    {
    }

    public string? Name { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Email { get; set; }
    public string Role { get; set; } = string.Empty;
}
