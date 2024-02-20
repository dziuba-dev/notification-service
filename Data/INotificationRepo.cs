using NotificationService.Models;

namespace NotificationService.Data
{
    public interface INotificationRepo
    {
        bool SaveChanges();

        IEnumerable<EmailToUser> GetAllUserEmail();
        IEnumerable<EmailToAdmin> GetAllAdminEmail();
        EmailToUser GetMailById(int message);
        void CreateEmail(EmailToUser mailU,EmailToAdmin mailA);
    }

}