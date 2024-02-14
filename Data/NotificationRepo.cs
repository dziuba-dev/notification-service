using NotificationService.Models;

namespace NotificationService.Data
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly AppDbContext _context;

        public NotificationRepo(AppDbContext context)
        {
            _context = context;
        }



        public void CreateEmail(EmailToUser mailU, EmailToAdmin mailA)
        {
            if (mailU == null) throw new ArgumentNullException(nameof(mailU));
            if (mailA == null) throw new ArgumentNullException(nameof(mailA));
            _context.EmailsToUser.Add(mailU);
            _context.EmailsToAdmin.Add(mailA);
        }

        public IEnumerable<EmailToAdmin> GetAllAdminEmail()
        {
            return _context.EmailsToAdmin.ToList();
        }

        public IEnumerable<EmailToUser> GetAllUserEmail()
        {
            return _context.EmailsToUser.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
