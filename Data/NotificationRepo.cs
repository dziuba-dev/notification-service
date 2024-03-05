using NotificationService.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotificationService.Data
{
    public class NotificationRepo : INotificationRepo
    {
        
        private readonly AppDbContext _context;
        private readonly SendGridOptions _options;

        public NotificationRepo(AppDbContext context,SendGridOptions options)
        {
            _context = context;

            _options = options;
        }



        public void CreateEmail(Email mail)
        {
            if (mail == null) throw new ArgumentNullException(nameof(mail));
            _context.Mails.Add(mail);
            SaveChanges();
        }
        public void DeleteEmail(Email mail)
        {
            if (mail == null) throw new ArgumentNullException(nameof(mail));
            _context.Mails.Remove(mail);
            SaveChanges();
        }
        public async void SendMail(Email mail,User user,User admin)
        {
            var subject = mail.Subject;
            var to = new EmailAddress(user.Email);
            var plainTextContent = mail.Message;
            var msg = MailHelper.CreateSingleEmail(_options.SendGridSender, to, subject, plainTextContent,null);
            var response = await _options.Client().SendEmailAsync(msg);
            to = new EmailAddress(admin.Email);
            var adminMsg = MailHelper.CreateSingleEmail(_options.SendGridSender, to,"mail sent to "+user.Email, null, "UserId " + user.Id + "<br>Message:<br>" + mail.Subject + "<br>" + mail.Message);
            var response2 = await _options.Client().SendEmailAsync(adminMsg);

        }

        public IEnumerable<Email> GetAllMail()
        {
            return _context.Mails.ToList();
        }
        
        public Email GetMailById(int id)
        {
            return _context.Mails.FirstOrDefault(e=>e.Id== id);
        }
        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(e => e.Id == id);
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges()>=0);
        }
    }
}
