using System.ComponentModel.DataAnnotations;

namespace SendEmalWebApi.Model
{
    public class Email : Entity
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}