using NotificationService.Models;

namespace NotificationService.Data
{
    public interface INotificationRepo
    {
        bool SaveChanges();

        IEnumerable<EmailToUser> GetAllUserEmail();
        IEnumerable<EmailToAdmin> GetAllAdminEmail();
        void CreateEmail(EmailToUser mailU,EmailToAdmin mailA);
    }

}