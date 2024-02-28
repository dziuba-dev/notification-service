using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dtos
{
    public class MailCreateDto
    {
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
