using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;
using SendEmalWebApi.Model;

namespace SendEmalWebApi.Services.EmailSenderService
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public  void SendEmail(ICollection<string> mails, string body, string subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("christine.boehm86@ethereal.email"));
            foreach (var mail in mails)
            {
                email.To.Add(MailboxAddress.Parse(mail));
            }
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Text) { Text = body };
            using var smtp = new SmtpClient();
            SmptSetSettings(smtp);
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private void SmptSetSettings(SmtpClient smtp)
        {
            var settings = _configuration.GetSection("SMPT_Server");
            var host = settings.GetRequiredSection("Host").Value;
            var port = settings.GetRequiredSection("Port").Value;
            var user = settings.GetRequiredSection("UserName").Value;
            var password = settings.GetRequiredSection("Password").Value;
            smtp.Connect(host, int.Parse(port!), SecureSocketOptions.StartTls);
            smtp.Authenticate(user, password);
        }
    }
}
