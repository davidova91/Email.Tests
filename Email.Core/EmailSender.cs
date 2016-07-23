using System.Net.Mail;

namespace Email.Core
{
    public class EmailSender
    {
        public void SendTestEmail(string from, string password, string to)
        {
            var client = new SmtpClient
            {
                Port = 25,
                Host = "smtp.yandex.ru",
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(@from, password)
            };
            var mail = new MailMessage(from, to)
            {
                Subject = "This is a subject",
                Body = "This is a test email"
            };
            client.Send(mail);
        }
    }
}