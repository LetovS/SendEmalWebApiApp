using MimeKit;

namespace SendEmalWebApi.Services.EmailSenderService
{
    public interface IEmailSenderService 
    {
        void SendEmail(ICollection<string> mails, string body, string subject);
    }
}
