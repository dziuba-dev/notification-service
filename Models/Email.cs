using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public class Email : Entity
    {
        [Key]
        public  int Id{ get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public Email(string subject,string message)
        {
            this.Subject = subject;
            this.Message = message;
        }
    }
}