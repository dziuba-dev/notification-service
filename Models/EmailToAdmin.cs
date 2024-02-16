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
        public  Guid UserId {  get; set; }
        public readonly DateTime CreatedAt = DateTime.Now;
        [Required]
        public string Email { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}