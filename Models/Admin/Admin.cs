using DreamCash.Services;

namespace DreamCash.Models.Admin
{
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void HidePassword()
        {
            Password = "";
        }

        public void EncryptPassword()
        {
            Password = PasswordService.Encrypt(Password);
        }

        public bool Login(string password)
        {
            if (PasswordService.Compare(password, Password))
            {
                return true;
            }
            return false;
        }
    }
}