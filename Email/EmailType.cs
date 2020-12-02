namespace DreamCash.Email
{
    public class EmailType
    {
        public EmailType(string value)
        {
            Value = value;
        }
        public string Value { get; set; }

        public static EmailType ResetPassword
        {
            get
            {
                return new EmailType("Email/EmailTemplates/ResetPassword.html");
            }
        }
    }
}