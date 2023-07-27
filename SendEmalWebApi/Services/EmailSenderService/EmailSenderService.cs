using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MailKit.Security;

namespace SendEmalWebApi.Services.EmailSenderService
{
    /// <summary>
    /// Emails sender.
    /// </summary>
    public class EmailSenderService : IEmailSenderService
    {
        private readonly IConfiguration _configuration;        
        private readonly string _host;       
        private readonly string _port;        
        private readonly string _user;       
        private readonly string _pass;
        /// <summary>
        /// Инииализация Email sender
        /// </summary>
        /// <param name="configuration">Настройки.</param>
        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
            var settings = _configuration.GetSection("SMPT_Server");
            _host = settings.GetRequiredSection("Host").Value!;
            _port = settings.GetRequiredSection("Port").Value!;
            _user = settings.GetRequiredSection("UserName").Value!;
            _pass = settings.GetRequiredSection("Password").Value!;
        }

        ///<inheritdoc/>
        public async Task SendEmailAsync(ICollection<string> mails, string body, string subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_user));
            foreach (var mail in mails)
            {
                email.To.Add(MailboxAddress.Parse(mail));
            }
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Text) { Text = body };
            using var smtp = new SmtpClient();
            smtp.Connect(_host, int.Parse(_port!), SecureSocketOptions.StartTls);
            smtp.Authenticate(_user, _pass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
