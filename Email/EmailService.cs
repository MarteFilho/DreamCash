using System;
using System.Net;
using System.Net.Mail;

namespace DreamCash.Email
{
    public class EmailService
    {
        public bool sendMail(string to, string assunto, string body)
        {
            string msge = "Erro ao enviar o e-mail, favor verifique os dados digitados!";
            string from = "help.saudevida@gmail.com";
            string displayName = "Saúde Vida - Recuperar Senha";
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
                client.Credentials = new NetworkCredential(from, "saudevida123");
                client.EnableSsl = true;

                client.Send(mail);
                msge = "E-mail enviado com êxito!";
            }
            catch
            {
                return false;
            }

            return true;
        }
        public string GetTemplateHtml(EmailType emailType)
        {
            var path = emailType.Value;
            return System.IO.File.ReadAllText(@emailType.Value);
        }
    }
}