using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using NotificationService.Data;
using SendGrid;
using SendGrid.Helpers.Mail;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddScoped<INotificationRepo, NotificationRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
var configuration = builder.Configuration;

builder.Services.AddSingleton<ISendGridClient>(sp =>
{
    var options = new SendGridClientOptions
    {
        ApiKey = configuration["SendGrid:ApiKey"]
    };
    return new SendGridClient(options);
});
var senderEmail = configuration["SendGrid:Sender"];
var senderName = configuration["SendGrid:SenderName"];

builder.Services.AddSingleton(new EmailAddress(senderEmail, senderName));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseRouting();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
    PrepDb.PrepPopulation(app);
}

app.UseHttpsRedirection();

app.Run();


