using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.IManagers;
using NotificationService.Domain.Services.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Managers;
using NotificationService.Infrastructure.NotificationChannels;
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

        builder.Services.AddScoped<INotificationChannel, EmailNotificationChannel>();
        builder.Services.AddScoped<INotificationChannel, SmsNotificationChannel>();
        builder.Services.AddScoped<INotificationChannel, PushNotificationChannel>();

        builder.Services.AddScoped<INotificationProviderManager, NotificationProviderManager>();
        builder.Services.AddScoped<INotificationChannelManager, NotificationChannelManager>();
        
        builder.Services.Configure<EmailNotificationChannelConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Channels:EmailChannel"));

        builder.Services.Configure<SmsNotificationChannelConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Channels:SmsChannel"));
        
        builder.Services.Configure<PushNotificationChannelConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Channels:PushChannel"));
        
        builder.Services.Configure<AmazonSnsProviderConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Providers:AmazonSns"));

        builder.Services.Configure<TwilioProviderConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Providers:Twilio"));

        builder.Services.Configure<VonageProviderConfiguration>(
            builder.Configuration.GetSection("NotificationSettings:Providers:Vonage"));
        
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