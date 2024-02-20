using System.ComponentModel.DataAnnotations;

namespace NotificationService.Models
{
    public abstract class Entity
    {
        [Key]
        [Required]
        public static Guid UserID = new Guid("f1b0e205-3e66-4bd7-a977-5a097cb056a7");
        public readonly DateTime CreatedAt=DateTime.Now;
    
    }
}
