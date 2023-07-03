using System.ComponentModel.DataAnnotations;

namespace SendEmalWebApi.Model
{
    public class RequestModel : Entity
    {
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string [] Recipients { get; set; }
    }
}
