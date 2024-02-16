using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class EmailToUser : Entity
    {
        public Guid UserId=Guid.NewGuid();
        public DateTime CreatedAt = DateTime.Now;
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}