using Microsoft.Extensions.Configuration;
using Rooms.App.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Rooms.App.Services;

public class CryptoService : ICryptoService
{
    private readonly byte[]? _key;
    private readonly byte[]? _iv;

    public CryptoService(IConfiguration configuration)
    {
        string? keyString = configuration["Crypto:cryptKey"];
        string? ivString = configuration["Crypto:CryptIv"];

        if (string.IsNullOrEmpty(keyString) || string.IsNullOrEmpty(ivString))
            throw new InvalidOperationException();

        _key = Encoding.UTF8.GetBytes(keyString);
        _iv = Encoding.UTF8.GetBytes(ivString);

        if (_key.Length != 32 || _iv.Length != 16)
            throw new InvalidOperationException();
    }

    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key!;
            aesAlg.IV = _iv!;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    public string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = _key!;
            aesAlg.IV = _iv!;

            ICryptoTransform encryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
