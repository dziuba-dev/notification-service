using Microsoft.EntityFrameworkCore;
using NotificationService.Models;

namespace NotificationService.Data
{
public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<EmailToUser> EmailsToUser { get; set; }
        public DbSet<EmailToAdmin> EmailsToAdmin { get; set; }
    }
}
