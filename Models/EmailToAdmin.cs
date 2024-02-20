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
        [Key]
        public  int Id {  get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public UserType UserType { get; set; }

        public EmailToAdmin(string email, string message,UserType userType)
        {
            this.Email = email;
            this.message = message;
            this.UserType = userType;
        }
    }
}