using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SendEmalWebApi.Model
{
    public class RequestModel : Entity
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [NotMapped]
        public List<string> Recipient { get; set; }
    }
}
