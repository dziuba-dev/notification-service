using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dtos
{
    public class UserMailCreateDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
