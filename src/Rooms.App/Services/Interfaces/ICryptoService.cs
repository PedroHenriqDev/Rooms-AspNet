using Rooms.Domain.Commands.Requests.Users;

namespace Rooms.App.Services.Interfaces;

public interface ICryptoService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}
