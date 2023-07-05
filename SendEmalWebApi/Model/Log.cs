using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SendEmalWebApi.Model
{
    /// <summary>
    /// Лог 
    /// </summary>
    public class Log : Entity
    {
        /// <summary>
        /// Тема емэйла.
        /// </summary>
        [Required]
        public string? Subject { get; set; }
        /// <summary>
        /// Текст емэйла.
        /// </summary>
        [Required]
        public string? Body { get; set; }
        /// <summary>
        /// Адреса рассылки.
        /// </summary>
        public virtual ICollection<Email>? Recipient { get; set; }
        /// <summary>
        /// Дата создания лога.
        /// Default value: DateTime.Now.Date.
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        /// <summary>
        /// Результат рассылки.
        /// Default value: Failed.
        /// </summary>
        public string Result { get; set; } = "Failed";
        /// <summary>
        /// Сообщение об ошибке рассылки.
        /// Default value: Empty.
        /// </summary>
        [Required]
        public string FieledMessage { get; set; } = string.Empty;
    }
}
