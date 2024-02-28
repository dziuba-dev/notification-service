using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public enum UserType
    {
        User=0,Admin=1
    }
    public class User : Entity
    {
        public User(string email, UserType userType)
        {
            this.Email=email;
            this.UserType=userType;
        }
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public UserType UserType { get; set; }
    }
}
