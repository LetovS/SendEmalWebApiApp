using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SendEmalWebApi.Model
{
    public class EntityDB : Entity
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public virtual ICollection<Email> Recipient { get; set; }
        //[ForeignKey(nameof(Recipient))]
        //public int RecipientId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;
        public string Result { get; set; } = "OK";
        [Required]
        public string FieledMessage { get; set; } = string.Empty;
    }
}
