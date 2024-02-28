namespace NotificationService.Data
{
    public class PrepDb
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
            if(!context.Users.Any())
            {
                context.Users.AddRange(
                    new Models.User("bar1walc@gmail.com",(Models.UserType)0),
                    new Models.User("bar1walc@gmail.com", (Models.UserType)1),
                    new Models.User("bar1walc@gmail.com", (Models.UserType)0)
                    );
                context.Mails.AddRange(
                    new Models.Email("subject1", "test message 1"),
                    new Models.Email("subject2", "test message 2"),
                    new Models.Email("subject3","test message 3")
                    );
                context.SaveChanges();
            }
        }
    }
}
