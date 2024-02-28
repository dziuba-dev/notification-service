using NotificationService.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotificationService.Data
{
    public class NotificationRepo : INotificationRepo
    {
        private readonly AppDbContext _context;

        public NotificationRepo(AppDbContext context)
        {
            _context = context;
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
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("praktykisend.grid@gmail.com", "Test");
            var subject = mail.Subject;
            var to = new EmailAddress(user.Email, "");
            var plainTextContent = mail.Message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent,null);
            var response = await client.SendEmailAsync(msg);
            to = new EmailAddress(admin.Email);
            var adminMsg = MailHelper.CreateSingleEmail(from, to,"mail sent to "+user.Email, null, "UserId " + user.Id + "<br>Message:<br>" + mail.Subject + "<br>" + mail.Message);
            var response2 = await client.SendEmailAsync(adminMsg);

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
