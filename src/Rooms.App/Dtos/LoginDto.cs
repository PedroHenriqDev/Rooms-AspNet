namespace Rooms.App.Dtos;

public class LoginDto
{
    public LoginDto(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }
    public string Password { get; set; }
}
