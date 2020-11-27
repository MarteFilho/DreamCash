using CryptSharp;

namespace DreamCash.Services
{
    public class PasswordService
    {
        public static string Encrypt(string password)
        {
            return Crypter.MD5.Crypt(password);
        }
        public static bool Compare(string password, string hash)
        {
            return Crypter.CheckPassword(password, hash);
        }
    }
}