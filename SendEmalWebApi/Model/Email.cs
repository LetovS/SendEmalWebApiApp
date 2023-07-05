using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SendEmalWebApi.Model
{
    /// <summary>
    /// Почтовый адрес 
    /// </summary>
    public class Email : Entity
    {
        /// <summary>
        /// Почтовый адрес
        /// </summary>
        [Required]        
        public string? EmailAddress { get; set; }
        /// <summary>
        /// Лог.
        /// </summary>
        public Log? Log { get; set; }
        /// <summary>
        /// Внешний ключ.
        /// </summary>
        [ForeignKey(nameof(Log))]
        public int LogId { get; set; }
    }
}