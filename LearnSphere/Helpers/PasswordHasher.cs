using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LearnSphere.API.Helpers;

public class PasswordHasher
{
    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] key = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100_000, 32);
        return Convert.ToBase64String(salt.Concat(key).ToArray());
    }

    public bool Verify(string password, string stored)
    {
        var bytes = Convert.FromBase64String(stored);
        var salt = bytes.Take(16).ToArray();
        var key = bytes.Skip(16).ToArray();
        var calc = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100_000, 32);
        return key.SequenceEqual(calc);
    }
}
