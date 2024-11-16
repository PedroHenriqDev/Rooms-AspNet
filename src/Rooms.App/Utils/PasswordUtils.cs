namespace Rooms.App.Utils;

public static class PasswordUtils
{
    public static string ConcatSalt(this string password, string salt)
    {
        return password + salt;
    }
}
