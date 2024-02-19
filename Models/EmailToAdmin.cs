using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public enum UserType
    {
        Admin = 0,
        User = 1,
        Other = 2
    }

    public class EmailToAdmin : Entity
    {
        public static Guid UserId = new Guid("6060b133-b202-4bdd-a27e-a854b6ceabdf");
        [Required]
        public string Email { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}