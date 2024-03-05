using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotificationService.Data
{
    public class SendGridOptions
    {
        public const string SendGrid = "SendGrid";
        public EmailAddress SendGridSender { get; set; }
        private string SendGridKey { get; set; }
        public SendGridClient Client()
        {
            return new SendGridClient(SendGridKey);
        }
    }
}
