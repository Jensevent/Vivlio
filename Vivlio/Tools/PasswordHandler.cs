using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Vivlio.Tools
{
    public class PasswordHandler
    {
        public string[] GenerateSaltAndHash(string password)
        {
            string[] data = new string[2];
            byte[] saltBytes = new byte[64];

            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);

            data[1] = Convert.ToBase64String(saltBytes); // Salt
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            data[0] = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)); // Hash

            return data;
        }

        public bool VerifyPassword(string passwordHash, string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == passwordHash; ;
        }
    }
}
