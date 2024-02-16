using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dtos
{
    public class GetMailDto
    {
        public readonly Guid UserId = Guid.NewGuid();
        public readonly DateTime CreatedAt;
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
