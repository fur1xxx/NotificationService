using NotificationService.Domain.IProvider;
using NotificationService.Domain.Services.Interfaces;
using NotificationService.Infrastructure.Providers;

namespace NotificationService.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddScoped<INotificationService, Infrastructure.Services.NotificationService>();
        
        builder.Services.AddScoped<INotificationProvider, TwilioNotificationProvider>();
        builder.Services.AddScoped<INotificationProvider, AmazonSnsNotificationProvider>();
        builder.Services.AddScoped<INotificationProvider, VonageNotificationProvider>();
        
        builder.Services.AddControllers();
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}