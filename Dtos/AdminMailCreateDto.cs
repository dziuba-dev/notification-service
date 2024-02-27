using NotificationService.Models;
using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dtos
{
    public class AdminMailCreateDto
    {
        public AdminMailCreateDto(string Email,string Message, UserType userType)
        {
            this.Email = Email;
            this.Message = Message;
            this.UserType = userType;
            this.UserId = 404;
        }

        public string Email { get; set; }
        public string Message { get; set; }
        public UserType UserType { get; set; }
        public int UserId { get; set; }
    }
}
