using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SendEmalWebApi.Model
{
    public class Email : Entity
    {
        [Required]
        public string EmailAddress { get; set; }
        public EntityDB EntityDB { get; set; }
        [ForeignKey(nameof(EntityDBId))]
        public int EntityDBId { get; set; }
    }
}