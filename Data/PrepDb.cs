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
                    new Models.EmailToUser() { Email = "bar1walc@gmail.com", Message="Test"},
                    new Models.EmailToUser() { Email = "bar1walc@gmail.com", Message = "Test2"});;
                context.EmailsToAdmin.AddRange(
                    new Models.EmailToAdmin("bar1walc@gmail.com","AdminTest",(Models.UserType)1));
                context.SaveChanges();
            }
        }
    }
}
