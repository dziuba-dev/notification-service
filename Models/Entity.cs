using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public abstract class Entity
    {
        [Key]
        public Guid Id {get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
