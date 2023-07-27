namespace SendEmalWebApi.Services.EmailSenderService
{
    /// <summary>
    /// Email sender
    /// </summary>
    /// <remarks>
    /// Этот интерфейс определяет сигнатуру методов необходимых для отправки электронной почты.
    /// </remarks>
    public interface IEmailSenderService 
    {
        /// <summary>
        /// Отправка электронной почты.
        /// </summary>
        /// <param name="mails">Адресаты отправки.</param>
        /// <param name="body">Текст электронной письма.</param>
        /// <param name="subject">Тема электронной письма.</param>
        void SendEmail(ICollection<string> mails, string body, string subject);
    }
}
