namespace Rooms.App.Dtos;

public class AuthenticationDto
{
    public AuthenticationDto(string token, DateTime expireDate, DateTime createdAt, bool authenticated = true)
    {
        Token = token;
        ExpireDate = expireDate;
        CreatedAt = createdAt;
        Authenticated = authenticated && ExpireDate < DateTime.Now;
    }

    public bool Authenticated { get; set; }
    public string Token { get; set; }
    public DateTime ExpireDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
