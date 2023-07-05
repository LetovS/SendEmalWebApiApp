using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SendEmalWebApi.Model
{
    /// <summary>
    /// Тело запроса
    /// /// </summary>
    public class Request : Entity
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
        
        public virtual List<string>? Recipient { get; set; }
    }
}
