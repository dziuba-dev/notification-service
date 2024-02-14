using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class EmailToUser
    {
        [Key]
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}