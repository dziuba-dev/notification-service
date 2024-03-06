using NotificationService.Models;

namespace NotificationService.Data
{
    public interface INotificationRepo
    {
        bool SaveChanges();

        IEnumerable<Email> GetAllMail();
        Email GetMailById(int id);
        User GetUserById(int id);
        Email CreateEmail(Email mail);
        void DeleteEmail(Email mail);
        void SendMail(Email mailId,User userId,User adminId);
    }

}