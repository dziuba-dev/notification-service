using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class EmailToUser : Entity
    {
        public static Guid UserId = new Guid("6060b133-b202-4bdd-a27e-a854b6ceabdf");
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}