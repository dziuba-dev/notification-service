using NotificationService.Models;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace NotificationService.Data
{
    public class NotificationRepo : INotificationRepo
    {
        
        private readonly AppDbContext _context;
        private readonly ISendGridClient _sendGridClient;
        private readonly EmailAddress _sender;

        public NotificationRepo(AppDbContext context, ISendGridClient sendGridClient, EmailAddress sender)
        {
            _context = context;
            _sendGridClient = sendGridClient;
            _sender = sender;
        }



        public Email CreateEmail(Email mail)
        {
            if (mail == null) throw new ArgumentNullException(nameof(mail));
            _context.Mails.Add(mail);
            SaveChanges();
            return mail;
        }
        public void DeleteEmail(Email mail)
        {
            if (mail == null) throw new ArgumentNullException(nameof(mail));
            _context.Mails.Remove(mail);
            SaveChanges();
        }
        public async void SendMail(Email mail,User user,User admin)
        {
            var msg = new SendGridMessage()
            {
                From = _sender,
                Subject = mail.Subject,
                PlainTextContent = mail.Message,
            };
            msg.AddTo(new EmailAddress(user.Email));
            var Amsg = new SendGridMessage()
            {
                From = _sender,
                Subject = "Sent mail with subject " + mail.Subject,
                PlainTextContent = "Message was: " + mail.Message + " UserID " + user.Id + " UserEmail " + user.Email,
            };
            Amsg.AddTo(new EmailAddress(admin.Email));
            var response = await _sendGridClient.SendEmailAsync(msg);
            response = await _sendGridClient.SendEmailAsync(Amsg);
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
