using System;
using System.Security.Cryptography;
using System.Text;

namespace Wba.EE.DeMiddelaerBart.Domain
{
    public static class EncryptionServise
    {
        public static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            rng.Dispose();
            return Convert.ToBase64String(buff);
        }
        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);

            sHA256ManagedString.Dispose();
            return Convert.ToBase64String(hash);
        }
        public static bool HashAreEqual(string plainTextInput, string hashedInput, string salt)
        {
            string newHashedPin = GenerateHash(plainTextInput, salt);
            return newHashedPin.Equals(hashedInput);
        }
    }
}
