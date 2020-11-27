namespace DreamCash.Models
{
    public class UserLoginViewModel
    {
        public UserLoginViewModel(string document, string password)
        {
            Document = document;
            Password = password;
        }

        public string Document { get; set; }
        public string Password { get; set; }
    }
}