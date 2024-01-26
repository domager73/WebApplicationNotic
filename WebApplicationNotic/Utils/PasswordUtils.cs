using System.Security.Cryptography;
using System.Text;

namespace WebApplicationNotic.Utils;

public static class PasswordUtils
{
    private static string GetPasswordHashed(string password) {
        var saltBytes = new byte[0x10];
        using (var random = new RNGCryptoServiceProvider()) {
            random.GetBytes(saltBytes);
        }
        
        var passwordBytes = Encoding.Unicode.GetBytes(password);
        
        var combinedBytes = saltBytes.Concat(passwordBytes).ToArray();
        
        byte[] hashBytes;
        
        using (var hashAlgorithm = HashAlgorithm.Create("HashAlgorithm")) {
            hashBytes = hashAlgorithm.ComputeHash(combinedBytes);
        }
        
        var PasswordHashed = Convert.ToBase64String(hashBytes);
        
        return PasswordHashed;
    }
}