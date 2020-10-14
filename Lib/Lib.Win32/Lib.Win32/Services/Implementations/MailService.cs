using Lib.Core;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Win32
{
    public class MailService : IMailService
    {
        public void Send(string username, string password, string from, string to, string subject, string body)
        {
            var client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(username, password);

            var mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mailMessage);
        }

        public void Send(string username, string password, string from, List<string> to, string subject, string body)
        {
            foreach (var address in to)
            {
                Send(username, password, from, address, subject, body);
            }
        }

        public Task SendAsync(string username, string password, string from, string to, string subject, string body)
        {
            return Task.Run(() => Send(username, password, from, to, subject, body));
        }

        public Task SendAsync(string username, string password, string from, List<string> to, string subject, string body)
        {
            return Task.Run(() => Send(username, password, from, to, subject, body));
        }
    }
}