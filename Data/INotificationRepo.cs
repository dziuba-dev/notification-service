using NotificationService.Models;

namespace NotificationService.Data
{
    public interface INotificationRepo
    {
        bool SaveChanges();

        IEnumerable<EmailToUser> GetAllUserEmail();
        IEnumerable<EmailToAdmin> GetAllAdminEmail();
        EmailToAdmin GetAdminMailById(int id);
        EmailToUser GetMailById(int id);
        void CreateEmail(EmailToUser mailU,EmailToAdmin mailA);
    }

}