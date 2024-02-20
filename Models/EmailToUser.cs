using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class EmailToUser : Entity
    {
        [Key]
        public  int Id{ get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}