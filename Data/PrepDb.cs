namespace NotificationService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        { 
            using(var serviceScope=app.ApplicationServices.CreateScope()) 
            {
             SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.EmailsToUser.Any()&&!context.EmailsToAdmin.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.EmailsToUser.AddRange(
                    new Models.EmailToUser() {UserId=Guid.NewGuid(), Email = "bar1walc@gmail.com", Message="Test"},
                    new Models.EmailToUser() {UserId=Guid.NewGuid(), Email = "bar1walc@gmail.com", Message = "Test2"});;
                context.EmailsToAdmin.AddRange(
                    new Models.EmailToAdmin() { Email = "bar1walc@gmail.com", UserId = Guid.NewGuid(), UserType = (Models.UserType)1, message = "Admin Test" });
                context.SaveChanges();
            }
        }
    }
}
