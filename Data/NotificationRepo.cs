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
            var latestMail = GetAllUserEmail().OrderByDescending(e => e.Id).FirstOrDefault();
            int id;
            if (latestMail != null) {id = latestMail.Id + 1; }
            else {id=1; }
            _context.EmailsToAdmin.Add(new EmailToAdmin(mailA.Email, mailA.message, mailA.UserType, id));
            SaveChanges();
            
        }

        public IEnumerable<EmailToAdmin> GetAllAdminEmail()
        {
            return _context.EmailsToAdmin.ToList();
        }

        public IEnumerable<EmailToUser> GetAllUserEmail()
        {
            return _context.EmailsToUser.ToList();
        }
        public EmailToAdmin GetAdminMailById(int id)
        {

            return _context.EmailsToAdmin.FirstOrDefault(e => e.Id == id);
        }
        public EmailToUser GetMailById(int id)
        {

            return _context.EmailsToUser.FirstOrDefault(e=>e.Id== id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
