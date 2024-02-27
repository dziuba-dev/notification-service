using NotificationService.Models;
using System.ComponentModel.DataAnnotations;

namespace NotificationService.Dtos
{
    public class GetAdminMailDto
    {   
        public int Id { get; set; }
        public string Email { get; set; }
        public string message { get; set; }
        public UserType UserType { get; set; }
        public int UserId { get; set; }
    }
}
