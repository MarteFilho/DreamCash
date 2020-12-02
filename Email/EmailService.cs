using System;
using System.Net;
using System.Net.Mail;

namespace DreamCash.Email
{
    public class EmailService
    {
        public bool sendMail(string to, string assunto, string body)
        {
            string from = "marcosrogerionino987654321@gmail.com";
            string displayName = "Dream Cash - Recuperar Senha";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = assunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(from, "Chapada2012-");
                client.EnableSsl = true;

                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetTemplateHtml(EmailType emailType)
        {
            var path = emailType.Value;
            return System.IO.File.ReadAllText(@emailType.Value);
        }
    }
}